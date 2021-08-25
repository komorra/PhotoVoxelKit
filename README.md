# PhotoVoxelKit
![pvicon](https://user-images.githubusercontent.com/1379649/130852259-f08ad429-a7bb-42f9-bdca-1b2ec0c60ebc.png)

SDK for extending PhotoVoxel editor and making procedural voxel scenes or assets

PhotoVoxel Official Website: https://photovoxel.com/

PhotoVoxel Twitter: https://twitter.com/PhotoVoxel

![foresttank](https://user-images.githubusercontent.com/1379649/130860858-aa55c0aa-8d07-4851-9b0c-4d566bbe7943.gif)

## Usage

1. Clone this repository
2. Open PhotoVoxelKit.sln inside PhotoVoxelKit directory via Visual Studio 2019
3. Create new class and make sure it is deriving from Procedural base class (in PhotoVoxelKit namespace)
4. Implement Create method (override from Procedural base class) in which you can create your voxel asset procedurally by using API methods given by IProcedural interface
5. Save your newly created asset and build solution to ensure you don't have compile time errors
6. Now you can test your asset in PhotoVoxel editor (available soon) or PhotoVoxel Viewer (available now at site download section: https://photovoxel.com/?page_id=192 )
7. If you are using PhotoVoxel Viewer go to File->Open... then navigate to your .cs script location and open

## Samples

Samples are located in PhotovoxelKit/ProceduralSamples directory, you can open them via PhotoVoxel editor or PhotoVoxel Viewer (link above).

## Future

We plan to extend PhotoVoxelKit in the nearby future, to include also possibility to create new tools, file format supports and integrations.

## Licensing

PhotoVoxelKit are licensed under MIT license, in opposite to PhotoVoxel editor and PhotoVoxel Viewer - they are closed source.
