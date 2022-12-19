# Deutorium
A Minecraft Substrate Frontend

INTRODUCTION
============
A 2D-Minecraft-Map-Viewer using the "Minecraft-Substrate/2.x"-Branch from 
Redwyre with abilities to modify the altitude and upmost blockid
by using png-images as a tampon.

2DO
===
- Find a way to iterate Blocks for height even quicker or get the data directly
  by members of chunk or a fonction in SUBSTRATE, which is not known to me yet.
- correct the mouse-precision when dragging the viewport(some jitter and inaccuracy
  in the graphics especially when zoomed in)
- get rid of the sluggish picturebox/arraycopy stuff and put everything to DirectX
  (i wanted to concentrate on making a working map-editor using substrate-SDK, not messing
  around with matrices, depthbuffers, hlsl and textures yet)


BUILDING THE SOURCE
===================
For more debug-control the Minecraft-Substrate-2.x code is referenced as SOURCE,
not as DLL! You have to inherit the 2.x branch in the project and then
build Deutorium from Source with the source of Minecraft-substrate/2.x!
Get the SOURCE FROM https://github.com/minecraft-dotnet/Substrate/tree/2.x
and unzip it in your users\XXX\downloads-folder!


HOW THE VIEWER WORKS
====================
Since i didnt find any data or function in Substrate to find the highest block quickly,
the editor has to iterate the chunks from the highest point (255, new build height is NOT
supported) till it finds a block that is not AIR (water and lava have special treatment) 
or height gets zero (new build height -64 NOT SUPPORTED).

For that process to consume too much time to get affordable results quickly, the process is split
up in two parts:

Phase 1:
(Blocks from this phase will be displayed with a greyscale)
Iterate down the Chunk in the first block from 255 till it gets an ID other than AIR.
Then Iterate the next block starting from the HEIGHT where the first (not-air)ID was found in the last
block with an addition of 4 steps up. if it hits an (not-air)ID directly, it steps up by 4 and starts
again, till iteration starts with an AIR-ID. 
This operation is quick, but very unprecise if you have floating plattforms so in this process
you will probably just see connected landmass

Phase 2:
(Blocks from this phase will be displayed in a 4-color-ramp 
for better view from black to red-yellow-green-white)
initiated when the screen area is filled with blocks starting from the middle of the viewport.
Every block is iterated from 255 downwards until it hits an (not-air) ID to return exact results,
water and lava have special treatnent.

When the view-position is moved, the loop switches back to Phase 1, but caches blocks by a
fast/exact state, rebuilding the view almost seamlesly.
The viewer loads/saves its cache upon opening or leaving the world with a choice of native(big files)
or compressed(slow!), to not have to iterate every block again when the world is reloaded. Applied but
not build tampons are part of this concept and will be saved with the cache, but can be removed by 
clicking the framed-x button in the toolbar.


IMAGES/TAMPON SEPCIFICATION
===========================
"Tampon"-Image" requirements:
- For best results use png files.
- use smaller images to keep control. 
  ("Build-Process" can take very long time on large images and freak out)
- max size "1024x1024".
- Image Alpha-Channel:  Density of how much altitude-change is applied. 
                        0 = no change, 25 = 10%, 255 = 100% etc.
Image RGB:              Just on/off atm. Later: Blockid by palette.





WARNING
=======
For most compatibility, use older Minecraft Versioned Worlds. If Deutorium crashes on loading,
i assume your worlds version is too "new"!

Always backup your world before using "build"!
Use everything at own risk!

Have fun!

