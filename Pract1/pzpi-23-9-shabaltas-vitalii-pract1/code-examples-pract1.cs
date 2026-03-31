 public interface IDevice
 {
     bool IsEnabled();
     void Enable();
     void Disable();
     void SetVolume(int percent);
 }
 
 public class Tv : IDevice
  {
      private bool _on = false;
      private int _volume = 30;
      
      public bool IsEnabled() => _on;
      public void Enable() => _on = true;
      public void Disable() => _on = false;
      public void SetVolume(int percent) => _volume = percent;
  }
  
  public class Radio : IDevice
  {
      private bool _on = false;
      private int _volume = 10;
      
      public bool IsEnabled() => _on;
      public void Enable() => _on = true;
      public void Disable() => _on = false;
      public void SetVolume(int percent) => _volume = percent;
  }
  
  public class RemoteControl
  {
      protected IDevice device;
      
      public RemoteControl(IDevice device)
      {
          this.device = device;
      }
      
      public void TogglePower()
      {
          if (device.IsEnabled())
              device.Disable();
          else
              device.Enable();
      }
  }
  
  public class AdvancedRemoteControl : RemoteControl
  {
      public AdvancedRemoteControl(IDevice device) : base(device) { }
      
      public void Mute()
      {
          device.SetVolume(0);
      }
  }
  
  class Program
  {
      static void Main()
      {
          IDevice tv = new Tv();
         RemoteControl remote = new RemoteControl(tv);
          remote.TogglePower();
          
          IDevice radio = new Radio();
          AdvancedRemoteControl advancedRemote = new AdvancedRemoteControl(radio);
          advancedRemote.TogglePower();
          advancedRemote.Mute();
      }
  }

