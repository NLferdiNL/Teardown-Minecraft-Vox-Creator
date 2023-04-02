using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileToVoxCore.Vox;
using FileToVoxCore.Schematics;
using FileToVoxCore.Extensions;
using Color = FileToVoxCore.Drawing.Color;
using System.Drawing.Imaging;

namespace MinecraftBlockCreator {
    public partial class Form1 : Form {
        private string selectedMaterial = "plastic";

        private Bitmap[] selectedImages;
        private string[] fileNames;

        private bool selectedPath = false;

        private Dictionary<string, int> materialOffsets = new Dictionary<string, int> {
            {"plastic", 11 * 8},
            {"heavy metal", 13 * 8},
            {"weak metal", 15 * 8},
            {"plaster", 17 * 8},
            {"brick", 19 * 8},
            {"concrete", 21 * 8},
            {"wood", 23 * 8},
            {"rock", 25 * 8},
            {"dirt", 27 * 8},
            {"grass", 29 * 8},
            {"glass", 31 * 8},
        };

        private Dictionary<string, int> materialColorCount = new Dictionary<string, int> {
            {"plastic", 16},
            {"heavy metal", 16},
            {"weak metal", 16},
            {"plaster", 16},
            {"brick", 16},
            {"concrete", 16},
            {"wood", 16},
            {"rock", 16},
            {"dirt", 16},
            {"grass", 16},
            {"glass", 8},
        };

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //RadioButton plastic, heavyMetal, weakMetal, plaster, brick, concrete, wood, rock, dirt, grass, glass;

            plasticMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            heavyMetalMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            weakMetalMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            plasterMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            brickMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            concreteMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            woodMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            rockMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            dirtMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            grassMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);
            glassMaterialRadioButton.Click += new EventHandler(materialRadioButton_Clicked);

            Schematic.CHUNK_SIZE = 16;
        }

        private void selectFileButton_Click(object sender, EventArgs e) {
            imageFileSelector.ShowDialog();
        }

        private void imageFileSelector_FileOk(object sender, CancelEventArgs e) {
            if (e.Cancel) {
                return;
            }

            if (imageFileSelector.FileNames.Length > 1) {
                selectedImages = new Bitmap[imageFileSelector.FileNames.Length];
                fileNames = new string[imageFileSelector.FileNames.Length];

                int index = 0;

                batchGenerationCount.Text = "Generated: 0 / " + imageFileSelector.FileNames.Length;

                foreach (string file in imageFileSelector.FileNames) {
                    selectedImages[index] = new Bitmap(Image.FromStream(File.OpenRead(file)));
                    fileNames[index] = Path.GetFileNameWithoutExtension(file);

                    if (selectedImages[index].Width != 16 || selectedImages[index].Height != 16) {
                        selectedImages = new Bitmap[1];
                        fileNames = new string[1];

                        MessageBox.Show("Loading canceled. Images aren't 16x16.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    index++;
                }

                selectedFileLabel.Text = "Selected file count: " + imageFileSelector.FileNames.Length;
                imagePreview.Image = selectedImages[0];
                return;
            }

            selectedImages = new Bitmap[1];

            selectedImages[0] = new Bitmap(Image.FromStream(imageFileSelector.OpenFile()));

            if (selectedImages[0].Width != 16 || selectedImages[0].Height != 16) {
                selectedImages = new Bitmap[1];
                fileNames = new string[1];

                MessageBox.Show("Loading canceled. Images aren't 16x16.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedFileLabel.Text = "Selected file: " + imageFileSelector.FileName;

            imagePreview.Image = selectedImages[0];
        }

        private void openSaveDialogButton_Click(object sender, EventArgs e) {
            if (selectedImages.Length > 1) {

                batchJobFolderSelect.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
                DialogResult dr = batchJobFolderSelect.ShowDialog();

                if (dr == DialogResult.OK) {
                    saveLocationLabel.Text = "Save location: " + batchJobFolderSelect.SelectedPath;
                    selectedPath = true;
                }
            } else {
                voxFileSaveLocation.ShowDialog();
            }
        }

        private void voxFileSaveLocation_FileOk(object sender, CancelEventArgs e) {
            if (e.Cancel) {
                return;
            }

            saveLocationLabel.Text = "Save location: " + voxFileSaveLocation.FileName;
        }

        private void generateVoxButton_Click(object sender, EventArgs e) {
            bool batchJobAndFolderSelected = selectedPath && selectedImages.Length > 1;
            bool singleJobAndFolderSelected = !string.IsNullOrEmpty(voxFileSaveLocation.FileName) && selectedImages.Length == 1;

            if (!batchJobAndFolderSelected && !singleJobAndFolderSelected) {
                MessageBox.Show("No save location selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (batchJobAndFolderSelected) {
                foreach (string filename in fileNames) {
                    string newFile = Path.Combine(batchJobFolderSelect.SelectedPath, filename + ".vox");
                    if (File.Exists(newFile)) {
                        DialogResult dr = MessageBox.Show("\"" + newFile + "\" already exists!\n" +
                                                          "Do you wish to overwrite this file?\n" +
                                                          "Pressing No cancels the generation process.\n" +
                                                          "If you do not wish to overwrite this file, please reselect the images without this image.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Cancel || dr == DialogResult.No || dr == DialogResult.Abort) {
                            MessageBox.Show("Generation canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }

            if (selectedImages.Length <= 0 || selectedImages[0] == null) {
                MessageBox.Show("No images loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = true;
            List<string> failedBatchFiles = new List<string>();

            if (selectedImages.Length == 1) {
                result = GenerateVoxAndSaveToPath(voxFileSaveLocation.FileName, selectedImages[0]);
            } else {
                for (int i = 0; i < selectedImages.Length; i++) {
                    string currFileName = Path.Combine(batchJobFolderSelect.SelectedPath, fileNames[i] + ".vox");

                    bool currResult = GenerateVoxAndSaveToPath(currFileName, selectedImages[i]);

                    if (!currResult) {
                        result = false;
                        failedBatchFiles.Add(fileNames[i]);
                    }

                    batchGenerationCount.Text = "Generated: "+ (i + 1) + " / " + fileNames.Length;
                }
            }

            if (result) {
                if (selectedImages.Length == 1) {
                    MessageBox.Show("Saved to " + voxFileSaveLocation.FileName + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Saved vox files to " + batchJobFolderSelect.SelectedPath + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("Failed to save vox files: " + string.Join(", ", failedBatchFiles) + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GenerateVoxAndSaveToPath(string path, Bitmap image) {
            List<uint> uintPalette;
            List<Color> palette = GeneratePaletteFromImage(image, out uintPalette);

            imagePreview.Image = image;

            Schematic schematic = new Schematic(uintPalette);

            GenerateSides(schematic, image);
            GenerateFill(schematic, image);

            VoxWriter voxWriter = new VoxWriter();

            bool result = voxWriter.WriteModel(path, null, schematic);

            uintPalette.Clear();
            palette.Clear();

            return result;
        }

        private void materialRadioButton_Clicked(object sender, EventArgs e) {
            RadioButton rb = sender as RadioButton;

            if (rb == null) {
                return;
            }

            selectedMaterial = rb.Text.ToLower();
        }

        private List<Color> GeneratePaletteFromImage(Bitmap imgBitmap, out List<uint> uintPalette) {
            List<Color> palette = new List<Color>();
            uintPalette = new List<uint>();

            int startIndex = 255 - materialOffsets[selectedMaterial];
            int materialCount = materialColorCount[selectedMaterial];

            Color materialColor = Color.FromArgb(255, 255, 0, 0);
            Color black = Color.FromArgb(255, 0, 0, 0);

            for (int i = 0; i < 256; i++) {
                palette.Add(black);
                uintPalette.Add(ColorToUInt(black));
            }

            palette[253] = Color.FromArgb(255, 255, 0, 0);
            uintPalette[253] = ColorToUInt(Color.FromArgb(255, 255, 0, 0));

            Dictionary<Color, List<Vector2>> imagePalette = new Dictionary<Color, List<Vector2>>();

            for (int x = 0; x < imgBitmap.Width; x++) {
                for (int y = 0; y < imgBitmap.Height; y++) {
                    Color currColor = ConvertFromSystem(imgBitmap.GetPixel(x, y));

                    if (imagePalette.ContainsKey(currColor)) {
                        imagePalette[currColor].Add(new Vector2(x, y));
                    } else {
                        imagePalette.Add(currColor, new List<Vector2>());
                        imagePalette[currColor].Add(new Vector2(x, y));
                    }
                }
            }

            Color[] colorKeys = imagePalette.Keys.ToArray();

            if (colorKeys.Length > materialCount) {
                for (int i = materialCount; i < colorKeys.Length; i++) {
                    Color currColor = colorKeys[i];

                    float minDistance = 1000000000;
                    Color closestColor = currColor;

                    for (int j = 0; j < materialCount; j++) {
                        Color otherColor = colorKeys[j];

                        float rDist = (otherColor.R - currColor.R) * (otherColor.R - currColor.R);
                        float gDist = (otherColor.G - currColor.G) * (otherColor.G - currColor.G);
                        float bDist = (otherColor.B - currColor.B) * (otherColor.B - currColor.B);

                        float currDistance = (float)Math.Sqrt(rDist + gDist + bDist);

                        if (currDistance < minDistance) {
                            minDistance = currDistance;
                            closestColor = otherColor;
                        }
                    }

                    List<Vector2> colorInstances = imagePalette[currColor];
                    System.Drawing.Color closestColorSystem = ConvertToSystem(closestColor);

                    for (int j = 0; j < colorInstances.Count; j++) {
                        Vector2 currVector = colorInstances[j];

                        imgBitmap.SetPixel(currVector.x, currVector.y, closestColorSystem);
                    }
                }

                for (int i = materialCount; i < colorKeys.Length; i++) {
                    imagePalette.Remove(colorKeys[i]);
                }
                    // Shrink palette and adjust bitmap for it.
            }/* else {
                for (int i = imagePalette.Count; i < materialCount; i++) {
                    imagePalette.Add(Color.FromArgb(255, i, 0, 0), 1);
                }
            }*/

            int colorIndex = 0;

            for (int i = startIndex; i > startIndex - imagePalette.Count; i--) {
                palette[i] = colorKeys[colorIndex];
                uintPalette[i] = ColorToUInt(colorKeys[colorIndex]);
                colorIndex++;
            }

            return palette;
        }

        public void GenerateSides(Schematic schematic, Bitmap selectedImage) {
            // Bottom
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    schematic.AddVoxel(x, 0, z, ConvertFromSystem(selectedImage.GetPixel(15 - x, 15 - z)));
                }
            }

            // Top
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    schematic.AddVoxel(x, 15, z, ConvertFromSystem(selectedImage.GetPixel(15 - x, 15 - z)));
                }
            }

            //Front 
            for (int x = 0; x < 16; x++) {
                for (int y = 0; y < 16; y++) {
                    schematic.AddVoxel(x, y, 0, ConvertFromSystem(selectedImage.GetPixel(15 - x, 15 - y)));
                }
            }

            //Back 
            for (int x = 0; x < 16; x++) {
                for (int y = 0; y < 16; y++) {
                    schematic.AddVoxel(x, y, 15, ConvertFromSystem(selectedImage.GetPixel(15 - x, 15 - y)));
                }
            }

            //Left 
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 16; y++) {
                    schematic.AddVoxel(0, y, z, ConvertFromSystem(selectedImage.GetPixel(15 - z, 15 - y)));
                }
            }

            //Right 
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 16; y++) {
                    schematic.AddVoxel(15, y, z, ConvertFromSystem(selectedImage.GetPixel(15 - z, 15 - y)));
                }
            }
        }

        public void GenerateFill(Schematic schematic, Bitmap selectedImage) {
            Random random = new Random();

            int margin = (int)marginNumberSelector.Value;

            for (int x = 1; x < 15; x++) {
                int offset = offsetRandomizeCheckBox.Checked ? random.Next(0, 15) : 0;

                for (int y = 1; y < 15; y++) {
                    for (int z = 1; z < 15; z++) {
                        int offsetY = margin + (y) % (15 - margin);
                        int offsetZ = margin + (z + offset) % (15 - margin);

                        //offsetY = margin + y % (15 - margin);
                        //offsetZ = margin + z % (15 - margin);
                        /*
                         * y = 1
                         * z = 14
                         * margin = 2
                         * 
                         * int offsetY = (2 + 1) % (15 - 2);
                         * int offsetZ = (2 + 14) % (15 - 2);
                         *
                         * int offsetY = (3) % (13);
                         * int offsetZ = (16) % (13);
                         * 
                         * int offsetY = 3;
                         * int offsetZ = 3;
                         */

                        /*int offsetY = 15 - margin - y % (15 - margin);
                        int offsetZ = 15 - margin - z % (15 - margin) + offset;

                        offsetY = offsetY % (16 - margin);
                        offsetZ = offsetZ % (16 - margin);*/

                        //int offsetY = 15 - margin + ((margin + y) % (16 - margin));
                        //int offsetZ = 15 - margin + ((z + offset + margin) % (16 - margin));
                        schematic.AddVoxel(x, y, z, ConvertFromSystem(selectedImage.GetPixel(offsetZ, offsetY)));
                    }
                }
            }
        }

        public Color ConvertFromSystem(System.Drawing.Color color) {
            return Color.FromArgb(255, color.R, color.G, color.B);
        }

        public System.Drawing.Color ConvertToSystem(Color color) {
            return System.Drawing.Color.FromArgb(255, color.R, color.G, color.B);
        }

        public uint ColorToUInt(Color color) {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8) | (color.B << 0));
        }
    }

    public class Vector2 {
        public int x = 0;
        public int y = 0;

        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}
