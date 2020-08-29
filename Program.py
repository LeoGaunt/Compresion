from PIL import Image

im = Image.open('image2.jpg') 
pix = im.load()
width, height = im.size #sets sizes of x and y heights
print (im.size)  # Get the width and hight of the image for iterating over
print (pix[3,4])  # Get the RGBA Value of the a pixel of an image

for y in range (0,height):
    for x in range (0,width):
        print (pix[x,y])