# GCoder

GCoder is a tool for reading and calculating 3D prints using the information found in the Gcode file, facilitating the calculation of costs, printing times and filament in a simpler way.

Disclaimer: It only works in Ultimaker Cura 4.13.1

## Configuration

As a first step, the following modules must be installed in Cura with the specified configurations.

1. Gcode Filename Format Plus

    The goal of using this module is to get the following parameters: file name, print time, line_width, layer_height and infill_sparse_density

    ![image](https://raw.githubusercontent.com/rbcr/GCoder/master/Screenshots/gcode_filename_format_plus_configuration.png)

    ```
    [base_name]-[T[print_time]]_[LW[line_width]mm][LH[layer_height]mm][IF[infill_sparse_density]]
    ```

    https://github.com/rgomezjnr/GcodeFilenameFormat
  

2. Configuring the printer
    
    In this part of the configuration, the gcode that will be generated by the printer is modified and this will be added in the final section of the file. It is important that the filament information has been previously added (price, brand, name).
    
    ![image](https://raw.githubusercontent.com/rbcr/GCoder/master/Screenshots/printer_settings_1.png)
    ![image](https://raw.githubusercontent.com/rbcr/GCoder/master/Screenshots/printer_settings_2.png)

    ```
    ; PRINT_INFO | v1 | filament_amount: {filament_amount} | filament_weight: {filament_weight} | filament_cost: {filament_cost} | print_time: {print_time} | material_name: {material_name} | brand: {material_brand} | jobname: {jobname}
    ```

## Usage

The main features of the tool:
- Load the files either by the open file dialog or by dragging and dropping into the table
- Copy the selected information to the clipboard
- Export the table information to a CSV file
- Delete the information loaded in the table

## Screenshots

![image](https://raw.githubusercontent.com/rbcr/GCoder/master/Screenshots/a7efa18d3ea6502106bd8edf3e7d1f67.gif)

![image](https://raw.githubusercontent.com/rbcr/GCoder/master/Screenshots/8d5f5f753ef0432d9a7fd8b6a8d2778f.gif)

![image](https://raw.githubusercontent.com/rbcr/GCoder/master/Screenshots/8023dc945e7c8491091e18f0cda5f70a.png)

![image](https://raw.githubusercontent.com/rbcr/GCoder/master/Screenshots/6a07b3302c2a79815ae79c20b9db0308.png)