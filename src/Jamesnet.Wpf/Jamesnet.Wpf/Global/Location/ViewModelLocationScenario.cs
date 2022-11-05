namespace Jamesnet.Wpf.Global.Location
{
    public class ViewModelLocationScenario
    {
        internal ViewModelLocatorCollection Publish()
        {
            ViewModelLocatorCollection Items = new();
            SetViewModelLocationScenario(Items);
            return Items;
        }

        public ViewModelLocationScenario()
        {

        }

        protected virtual void SetViewModelLocationScenario(ViewModelLocatorCollection items)
        {
        }
    }
}
