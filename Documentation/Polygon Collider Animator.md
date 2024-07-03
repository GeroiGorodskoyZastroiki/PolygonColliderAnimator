# Polygon Collider Animator
## How It Works
When Sprite Renderer changes the sprite field, the script changes Polygon Collider 2D.
## Setup
Just add Polygon Collider Animator script to an object. The necessary scripts will be added automatically if they are not there.
## Collider Editing
You can enable 'Generate Physics Shape' option in Sprite Import Settings for colliders to be generated automatically. Or you can edit them by hand in Sprite Editor window in Custom Physics Shape mode. If there is no collider for the current frame and 'Generate Physics Shape' option is off the script will keep the previous shape or not generate shape at all if there is no previous shape.