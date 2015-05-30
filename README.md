UnityGyazo
==========

Simple gyazo client for Unity4.6.x/5.x.

## Usage
1. Create an empty game object.
2. Attach "Gyazo.cs" to it.
3. Configure the local file-path and uploadURL if necessary.
4. Just call Gyazo#UploadFileAsync then gyazo object will start to upload the image asynchronously.

## Compatibility
- Unity4.6.x
- Unity5.x

## How to get the Image URL on gyazo-server?
  Web response from gyazo-server is set to Gyazo#Response property asynchronously.
  If status is SUCCESS, image-URL is set there.

## How to handle the uploading process?
- ```Init```: Default status
- ```Uploading```: Connecting to gyazo-server and uploading local image
- ```Success```: Succeeded to upload image
- ```Error```: Error occured during uploading

## Advanced
If you want to upload images to your own gyazo-server, specify the "UploadURL" param in the inspector (or source code).Check the included demo scene also.

## License
MIT license (© 2015 Shulla Cignoir)
