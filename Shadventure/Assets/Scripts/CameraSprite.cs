using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OpenCVForUnity
{
    /// <summary>
    /// WebCamTextureToMat Example
    /// An example of converting a WebCamTexture image to OpenCV's Mat format.
    /// </summary>
    public class CameraSprite : MonoBehaviour
    {
        /// <summary>
        /// Set this to specify the name of the device to use.
        /// </summary>
        public string requestedDeviceName = null;

        /// <summary>
        /// Set the requested width of the camera device.
        /// </summary>
        public int requestedWidth = 640;
        
        /// <summary>
        /// Set the requested height of the camera device.
        /// </summary>
        public int requestedHeight = 360;
        
        /// <summary>
        /// Set the requested to using the front camera.
        /// </summary>
        public bool requestedIsFrontFacing = false;

        /// <summary>
        /// Set the threshold for converting grey image to binary image
        /// </summary>
        public int threshold = 70;

        /// <summary>
        /// The webcam texture.
        /// </summary>
        WebCamTexture webCamTexture;

        /// <summary>
        /// The webcam device.
        /// </summary>
        WebCamDevice webCamDevice;

        /// <summary>
        /// The colors.
        /// </summary>
        Color32[] colors;

        /// <summary>
        /// The texture.
        /// </summary>
        Texture2D texture;

        GameObject shadow_object;

        float pixelPerUnit = 16.0f;

        /// <summary>
        /// Indicates whether this instance is waiting for initialization to complete.
        /// </summary>
        bool isInitWaiting = false;

        /// <summary>
        /// Indicates whether this instance has been initialized.
        /// </summary>
        bool hasInitDone = false;

        // Use this for initialization
        void Start ()
        {
            Initialize ();
            Initialize_sprite();
        }

        private void Initialize_sprite()
        {
            texture = new Texture2D(requestedWidth, requestedHeight);
            // shadow_object = new GameObject("Shadow", typeof(SpriteRenderer));
            shadow_object = GameObject.Find("Shadow");
            shadow_object.transform.localScale = new Vector3(-1, 1, 1);

            GameObject scene_camera = GameObject.Find("Main Camera");
            // Debug.Log(scene_camera.transform.position.x);

            // shadow_object.transform.position = new Vector3(-requestedWidth/200.0f, -requestedHeight/200.0f, 0);
            shadow_object.transform.position = new Vector3(
                scene_camera.transform.position.x + requestedWidth/2/pixelPerUnit,
                scene_camera.transform.position.y - requestedHeight/2/pixelPerUnit, 0);

            
            Debug.Log("requestedHeight " + requestedHeight);

            Sprite shadow_sprite = Sprite.Create(texture, new UnityEngine.Rect(0, 0, requestedWidth, requestedHeight), Vector2.zero, pixelPerUnit, 1, SpriteMeshType.FullRect);
            shadow_object.GetComponent<SpriteRenderer>().sprite = shadow_sprite;

            shadow_object.AddComponent(typeof(PolygonCollider2D));
        }

        /// <summary>
        /// Initialize of web cam texture.
        /// </summary>
        private void Initialize ()
        {
            if (isInitWaiting)
                return;

            StartCoroutine (_Initialize ());
        }

        /// <summary>
        /// Initialize of webcam texture.
        /// </summary>
        /// <param name="deviceName">Device name.</param>
        /// <param name="requestedWidth">Requested width.</param>
        /// <param name="requestedHeight">Requested height.</param>
        /// <param name="requestedIsFrontFacing">If set to <c>true</c> requested to using the front camera.</param>
        private void Initialize (string deviceName, int requestedWidth, int requestedHeight, bool requestedIsFrontFacing)
        {
            if (isInitWaiting)
                return;

            this.requestedDeviceName = deviceName;
            this.requestedWidth = requestedWidth;
            this.requestedHeight = requestedHeight;
            this.requestedIsFrontFacing = requestedIsFrontFacing;

            Debug.Log("I guess this is never called.");

            StartCoroutine (_Initialize ());
        }

        /// <summary>
        /// Initialize of webcam texture by coroutine.
        /// </summary>
        private IEnumerator _Initialize ()
        {
            if (hasInitDone)
                Dispose ();

            isInitWaiting = true;

            if (!String.IsNullOrEmpty (requestedDeviceName)) {
                //Debug.Log ("deviceName is "+requestedDeviceName);
                // webCamTexture = new WebCamTexture (requestedDeviceName, requestedWidth, requestedHeight);
                webCamTexture = new WebCamTexture (requestedDeviceName);
            } else {
                //Debug.Log ("deviceName is null");
                // Checks how many and which cameras are available on the device
                for (int cameraIndex = 0; cameraIndex < WebCamTexture.devices.Length; cameraIndex++) {
                    if (WebCamTexture.devices [cameraIndex].isFrontFacing == requestedIsFrontFacing) {

                        //Debug.Log (cameraIndex + " name " + WebCamTexture.devices [cameraIndex].name + " isFrontFacing " + WebCamTexture.devices [cameraIndex].isFrontFacing);
                        webCamDevice = WebCamTexture.devices [cameraIndex];
                        // webCamTexture = new WebCamTexture (webCamDevice.name, requestedWidth, requestedHeight);
                        // FIXME
                        webCamTexture = new WebCamTexture (webCamDevice.name);

                        break;
                    }
                }
            }

            if (webCamTexture == null) {
                if (WebCamTexture.devices.Length > 0) {
                    webCamDevice = WebCamTexture.devices [0];
                    // webCamTexture = new WebCamTexture (webCamDevice.name, requestedWidth, requestedHeight);
                    // FIXME
                    webCamTexture = new WebCamTexture (webCamDevice.name);
                } else {
                    // webCamTexture = new WebCamTexture (requestedWidth, requestedHeight);
                    // FIXME
                    webCamTexture = new WebCamTexture ();
                    
                }
            }


            Debug.Log("WebcamTexture.Width " + webCamTexture.width + " WebcamTexture.Height " + webCamTexture.height);

            // Starts the camera.
            webCamTexture.Play ();
            // GameObject quad_object = GameObject.Find("Quad");
            // quad_object.transform.localScale = new Vector3(0, 0, 0);
            // quad_object.SetActive(false);

            while (true) {
                // If you want to use webcamTexture.width and webcamTexture.height on iOS, you have to wait until webcamTexture.didUpdateThisFrame == 1, otherwise these two values will be equal to 16. (http://forum.unity3d.com/threads/webcamtexture-and-error-0x0502.123922/).
                // #if UNITY_IOS && !UNITY_EDITOR && (UNITY_4_6_3 || UNITY_4_6_4 || UNITY_5_0_0 || UNITY_5_0_1)
                // if (webCamTexture.width > 16 && webCamTexture.height > 16) {
                // #else
                if (webCamTexture.didUpdateThisFrame) {
                    // #if UNITY_IOS && !UNITY_EDITOR && UNITY_5_2                                    
                    // while (webCamTexture.width <= 16) {
                    //     webCamTexture.GetPixels32 ();
                    //     yield return new WaitForEndOfFrame ();
                    // } 
                    // #endif
                    // #endif

                    Debug.Log ("name " + webCamTexture.name + " width " + webCamTexture.width + " height " + webCamTexture.height + " fps " + webCamTexture.requestedFPS);
                    Debug.Log ("videoRotationAngle " + webCamTexture.videoRotationAngle + " videoVerticallyMirrored " + webCamTexture.videoVerticallyMirrored + " isFrongFacing " + webCamDevice.isFrontFacing);

                    isInitWaiting = false;
                    hasInitDone = true;

                    OnInited ();

                    break;
                } else {
                    yield return 0;
                }
            }
        }

        /// <summary>
        /// Releases all resource.
        /// </summary>
        private void Dispose ()
        {
            isInitWaiting = false;
            hasInitDone = false;

            if (webCamTexture != null) {
                webCamTexture.Stop ();
                webCamTexture = null;
            }
        }

        /// <summary>
        /// Initialize completion handler of the webcam texture.
        /// </summary>
        private void OnInited ()
        {
            if (colors == null || colors.Length != webCamTexture.width * webCamTexture.height)
                colors = new Color32[webCamTexture.width * webCamTexture.height];
            if (texture == null || texture.width != webCamTexture.width || texture.height != webCamTexture.height)
                texture = new Texture2D (webCamTexture.width, webCamTexture.height, TextureFormat.RGBA32, false);

            // gameObject.GetComponent<Renderer>().material.mainTexture = texture;

            // gameObject.transform.localScale = new Vector3 (webCamTexture.width, webCamTexture.height, 1);
            // gameObject.transform.localScale = new Vector3 (0, 0, 0);
            Debug.Log ("Screen.width " + Screen.width + " Screen.height " + Screen.height + " Screen.orientation " + Screen.orientation);
        }

        // Update is called once per frame
        void Update ()
        {
            if (hasInitDone && webCamTexture.isPlaying && webCamTexture.didUpdateThisFrame) {

                // change bg to transparent
                Color[] pixels = webCamTexture.GetPixels();
                for(int i = 0; i < pixels.Length; i++) {
                    if((pixels[i].grayscale * 255) < threshold){
                        pixels[i] = new Color(0, 0, 0, 1);
                    } else {
                        pixels[i] = new Color(0, 0, 0, 0);                        
                    }
                }
                texture.SetPixels(pixels);
                texture.Apply();
                Destroy(shadow_object.GetComponent(typeof(PolygonCollider2D)));
                shadow_object.AddComponent(typeof(PolygonCollider2D));

            }
        }

        /// <summary>
        /// Raises the destroy event.
        /// </summary>
        void OnDestroy ()
        {
            Dispose ();
        }
    }
}