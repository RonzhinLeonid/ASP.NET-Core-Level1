﻿namespace WebApplication1.ViewModels
{
    public class SectionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<SectionViewModel> ChildSections { get; set; } = new();
    }
}
