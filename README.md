# DXF_To_Revit

https://user-images.githubusercontent.com/76973221/173254404-f21d0645-4615-46ee-8561-e26b4bb93552.mp4

## Description

DXF_To_Revit is a professional Revit API plugin that enables you to read DXF files using the netDXF library and seamlessly draw grids, walls, and floors in Revit using the Revit API.

## Getting Started

### Prerequisites

- Revit version up to 2021.

### Installation

1. Copy the contents of the "DLLs Package" folder to your Revit Add-in path.
2. Open the provided Revit project in the DXF files folder to test the plugin with the attached DXF file.

## Usage

To use the DXF_To_Revit plugin, follow these steps:

1. Launch Revit and open your desired project.
2. Navigate to the Add-ins menu and select the DXF_To_Revit plugin.
3. Specify the path to the DXF file you want to import.
4. Click the "Import" button to initiate the import process.
5. The plugin will read the DXF file, extract the grid lines, walls, and floors, and create the corresponding elements in the Revit project.

## DXF File Structure

To ensure successful import, make sure your DXF file adheres to the following structure:

- Grids: Represented as separated lines with the layer name "Grids".
- Walls: Represented as separated lines with the layer name "Walls".
- Floors: Represented as separated lines with the layer name "Floor".

## Upcoming Updates

We are continuously working on improving the DXF_To_Revit plugin to enhance its functionality and compatibility with newer versions of Revit. Stay tuned for upcoming updates and new features.

## Contributing

We welcome contributions from the community to make DXF_To_Revit even better. If you encounter any issues, have ideas for enhancements, or would like to contribute code, please check out the [contribution guidelines](CONTRIBUTING.md).

## License

DXF_To_Revit is released under the [MIT License](LICENSE). Please review the license file for more details.

## Disclaimer

Please note that DXF_To_Revit is provided as-is, and any usage is at your own risk. We make no warranties or guarantees regarding its functionality or suitability for your specific purposes.
