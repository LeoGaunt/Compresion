import numpy
from PIL import Image

def getImage(imagePath):
    #Get a numpy array of an image so that one can access values[x][y].
    image = Image.open(imagePath, "r")
    width, height = image.size
    pixelValues = list(image.getdata())
    if image.mode == "RGB":
        channels = 3
    elif image.mode == "L":
        channels = 1
    else:
        print("Unknown mode: %s" % image.mode)
        return None
    pixelValues = numpy.array(pixelValues).reshape((width, height, channels))
    return pixelValues

image = getImage("/Users/leogaunt/Documents/Programming/Compression/image2.JPG")

print(image[0])
print(image.shape)

pixelFile = open("pixels.txt", "w")
Record = (image[0])
pixelFile.write(Record)
pixelFile.close()