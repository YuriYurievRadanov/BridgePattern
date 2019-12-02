using System;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoAbstraction video = new VideoRefinedAbstraction();
            video.VideoMode = new OpenGLMode();
            video.ShowScreen();

            Console.ReadLine();
        }
    }
    /// <summary>
    /// Implementor Class
    /// </summary>
    public interface IVideoMode
    {
        string GetScreen();
    }

    /// <summary>
    /// ConcreteImplementor for OpenGL
    /// </summary>
    public class OpenGLMode : IVideoMode
    {
        const string MODE_NAME = "OpenGL Mode";
        public string GetScreen()
        {
            return string.Format("Video started with {0}", MODE_NAME);
        }
    }

    /// <summary>
    /// ConcreteImplementor for Direct3D
    /// </summary>
    public class Direct3DMode : IVideoMode
    {
        const string MODE_NAME = "Direct3D Mode";
        public string GetScreen()
        {
            return string.Format("Video started with {0}", MODE_NAME);
        }
    }

    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public class VideoAbstraction
    {
        protected IVideoMode _videoMode;
        // Property
        public IVideoMode VideoMode
        {
            set { _videoMode = value; }
        }

        public virtual void ShowScreen()
        {
            Console.WriteLine(_videoMode.GetScreen());
        }
    }

    public class VideoRefinedAbstraction : VideoAbstraction
    {
        public override void ShowScreen()
        {
            Console.WriteLine(_videoMode.GetScreen());
        }
    }
}
