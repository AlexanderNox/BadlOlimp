using Zenject;

namespace Installers
{
    public class InputMapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputMap instance = new InputMap();

            instance.Enable();

            Container
                .Bind<InputMap>()
                .FromInstance(instance)
                .AsSingle();
        }
    }
}