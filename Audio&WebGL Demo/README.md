# Audio for Unity

### To get started:

Create an empty Game Object, add the AudioManager.cs script to it.  
Audio clips and properties can be added here and all managed in the one object.  
Create a prefab to add to multiple scenes.  

### Example access from other scripts:

```
FindObjectOfType<AudioManager>().Play("sound_name") // Sound name is the public string defined in Sound.cs
```
