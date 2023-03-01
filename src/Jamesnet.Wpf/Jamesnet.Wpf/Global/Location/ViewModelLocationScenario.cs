namespace Jamesnet.Wpf.Global.Location
{
    public abstract class ViewModelLocationScenario
    {
        internal ViewModelLocatorCollection Publish()
        {
            ViewModelLocatorCollection Items = new();
            Match(Items);
            return Items;
        }

        public ViewModelLocationScenario()
        {

        }

        protected abstract void Match(ViewModelLocatorCollection items);
    }
}
