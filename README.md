# Deutorium
Minecraft Substrate Frontend

A 2D-Minecraft-Map-Viewer using the "Minecraft-Substrate/2.x"-Branch 
with abilities to modify the altitude and upmost blockid
by using png-images as a tampon.

"Tampon"-Image" requirements:
- For best results use png files.
- use smaller images to keep control. 
  ("Build-Process" can take very long time on large images and freak out)
- max size "1024x1024".
- Image Alpha-Channel:  Density of how much altitude-change is applied. 
                        0 = no change, 25 = 10%, 255 = 100% etc.
Image RGB:              Just on/off atm. Later: Blockid by palette.

For most compatibility, use older Minecraft Versioned Worlds. If Deutorium crashes on loading,
i assume your worlds version is too "new"!

Always backup your world before using "build"!
Use everything at own risk!

