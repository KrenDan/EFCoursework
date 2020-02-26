using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.WPF.ViewModels.Factories
{
    public class TestViewModelFactory : IViewModelFactory<TestViewModel>
    {
        public TestViewModel CreateViewModel()
        {
            return new TestViewModel();
        }
    }
}
