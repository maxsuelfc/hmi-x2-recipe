//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neo.ApplicationFramework.Generated
{
	using Neo.ApplicationFramework.Tools.Actions;
	
	
	public partial class ProjectConfiguration : Neo.ApplicationFramework.Tools.ProjectConfiguration.ProjectConfiguration, Neo.ApplicationFramework.Interfaces.ISupportMultiLanguage
	{
		
		public ProjectConfiguration()
		{
			this.InitializeComponent();
			this.ApplyLanguageInternal();
		}
		
		private void InitializeComponent()
		{
			Neo.ApplicationFramework.Tools.ProjectConfiguration.FontSettings FontSettings1 = new Neo.ApplicationFramework.Tools.ProjectConfiguration.FontSettings();
			Neo.ApplicationFramework.Tools.ProjectConfiguration.FontSettings FontSettings2 = new Neo.ApplicationFramework.Tools.ProjectConfiguration.FontSettings();
			// 
			// ProjectConfiguration
			// 
			this.UISettings.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187))))), System.Drawing.Color.White, Neo.ApplicationFramework.Interfaces.FillDirection.VerticalBottomToTop);
			this.UISettings.ControlBackground = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76))))), Neo.ApplicationFramework.Interfaces.FillDirection.VerticalBottomToTop);
			this.UISettings.ControlForeground = System.Drawing.Color.White;
			this.UISettings.Font = FontSettings1;
			this.UISettings.Foreground = System.Drawing.Color.Black;
			this.UISettings.ListItemHeight = 35;
			this.UISettings.MessageBoxDelay = System.TimeSpan.Parse("00:00:20");
			FontSettings2.SizePixels = 22;
			this.UISettings.TitleFont = FontSettings2;
			this.ConnectDataBindings();
		}
		
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual void ConnectDataBindings()
		{
		}
		
		private void InitializeObjectCreations()
		{
		}
		
		private void InitializeBeginInits()
		{
		}
		
		private void InitializeEndInits()
		{
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		private void ApplyLanguageInternal()
		{
			Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager resources = new Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager(typeof(ProjectConfiguration));
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		void Neo.ApplicationFramework.Interfaces.ISupportMultiLanguage.ApplyLanguage()
		{
			this.ApplyLanguage();
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		protected virtual void ApplyLanguage()
		{
			this.ApplyLanguageInternal();
		}
	}
}
