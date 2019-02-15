using Zenject;
namespace Geekbrains {
	public class GameInstaller : MonoInstaller {
		public override void InstallBindings()
		{
			Container.Bind<FlashLightModel>().AsSingle();
			Container.Bind<FlashLightUiText>().AsSingle();
		}

	}
}
 