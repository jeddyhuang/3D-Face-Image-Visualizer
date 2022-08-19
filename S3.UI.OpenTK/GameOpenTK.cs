using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using S3.Framework.Entities;
using S3.Services;
using S3.UI.OpenTK.Helpers;
using S3.UI.OpenTK.Models;
using S3.UI.OpenTK.Primitives;
using S3.ViewModels;

namespace S3.UI.OpenTK
{
    public sealed class GameOpenTK : GameWindow
    {
        private bool _applyTexture;
        private bool _applyPoints;

        private Camera Camera { get; set; }

        public ObjDataViewModel DataModel { get; set; }

        private List<TextureMaterial2D> Textures { get; set; }


        /// <summary>   
        /// Default constructor 
        /// </summary>
        public GameOpenTK(int width, int height, string title) : base(width, height)
        {
            Title = title;

            this.Load += OnLoad;
            this.Resize += OnResize;
            this.UpdateFrame += OnUpdateFrame;
            this.RenderFrame += OnRenderFrame;

            this.KeyDown += OnKeyDown;

            this.MouseMove += OnMouseMove;
            this.MouseWheel += OnMouseWheel;

            Camera = new Camera();

            DataModel = new ObjDataViewModel();
            Textures = new List<TextureMaterial2D>();

            _applyTexture = false;
            _applyPoints = false;
        }


        /// <summary>
        /// Runs when the window is first loaded    
        /// </summary>
        private void OnLoad(object sender, EventArgs e)
        {
            InitialSettings();

            var materials = DataModel.ObjDataModel.Materials.Where(m => m.FilePath != null);
            foreach (var material in materials)
            {
                var texture = ContentPipe.LoadTexture(material);
                Textures.Add(texture);
            }
        }

        private void InitialSettings()
        {
            VSync = VSyncMode.On;

            GL.ClearColor(Color.CornflowerBlue);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            if (_applyTexture)
            {
                GL.Enable(EnableCap.Texture2D);
            }
        }

        /// <summary>
        /// Runs when the window is first created, and when windows is resized.
        /// </summary>
        private void OnResize(object sender, EventArgs e)
        {
            var size = Width <= Height ? Width : Height;
            GL.Viewport(0, 0, size, size);

            Camera = new Camera();

            var eye = new Vector3(0, 100, 200);
            var look = new Vector3(0, 0, 0);
            Camera.Set(eye, look);
            Camera.SetProjectionMatrix(MathHelper.PiOver4, 1.0f, 1.0f, 800.0f);
        }

        private void OnUpdateFrame(object sender, FrameEventArgs e)
        {
            //Title = $" (Vsync: {VSync}) FPS: {1f / e.Time:0}";
        }

        private void OnRenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Camera.SetModelViewMatrix();


            GL.Color3(Color.Gray);
            GL.PolygonMode(MaterialFace.FrontAndBack, _applyTexture ? PolygonMode.Fill : PolygonMode.Line);
            var currentMtl = string.Empty;
            var currentTexture = new TextureMaterial2D();
            foreach (var face in DataModel.ObjDataModel.Faces)
            {
                if (face.Index == 0) continue;

                if (_applyTexture && face.UseMtl != currentMtl)
                {
                    currentMtl = face.UseMtl;
                    currentTexture = Textures.FirstOrDefault(t => t.MaterialName == face.UseMtl);

                    if (currentTexture.IsValid)
                    {
                        GL.BindTexture(TextureTarget.Texture2D, currentTexture.Id);
                    }
                }

                GL.Begin(PrimitiveType.Polygon);
                foreach (var detail in face.VertexDetails)
                {
                    if (_applyTexture && currentTexture.IsValid)
                    {
                        //TODO: Y is inversed
                        GL.TexCoord2(detail.VertexTexture.X, 1 - detail.VertexTexture.Y);
                    }

                    GL.Vertex3(detail.Vertex.X, detail.Vertex.Y, detail.Vertex.Z);
                    GL.Normal3(detail.VertexNormal.I, detail.VertexNormal.J, detail.VertexNormal.K);
                }
                GL.End();
            }

            if (_applyPoints)
            {
                foreach (var positionInfo in DataModel.PositionVertexFaces)
                {
                    var vertext = positionInfo.Vertex;
                    var cube = new CubeBuilder().New()
                        .WithCenter(new Vector3(vertext.X, vertext.Y, vertext.Z))
                        .WithLength(1)
                        .WithColor(Color.Blue)
                        .Build();

                    cube.Draw();
                }
            }

            this.SwapBuffers();
        }

        private void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    this.Exit();
                    break;

                case Key.T:
                    this._applyTexture = !_applyTexture;
                    if (_applyTexture)
                    {
                        GL.Enable(EnableCap.Texture2D);
                    }
                    else
                    {
                        GL.Disable(EnableCap.Texture2D);
                    }
                    break;

                case Key.K:
                    this._applyPoints = !_applyPoints;
                    break;

                case Key.Left:
                    Camera.Slide(-10, 0, 0);
                    break;

                case Key.Right:
                    Camera.Slide(10, 0, 0);
                    break;

                case Key.Up:
                    Camera.Slide(0, 10, 0);
                    break;

                case Key.Down:
                    Camera.Slide(0, -10, 0);
                    break;

                default:
                    break;
            }
        }

        private void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            if (e.Mouse.LeftButton == ButtonState.Pressed)
            {
                Camera.Slide(-e.XDelta * 0.5f, e.YDelta * 0.5f, 0);
            }
            else if (e.Mouse.RightButton == ButtonState.Pressed)
            {
                Camera.Pitch(e.YDelta * 0.1f); //up down
                Camera.Yaw(e.XDelta * 0.1f); //left right
            }

        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Camera.Slide(0, 0, e.Delta * 10);
        }

    }
}
