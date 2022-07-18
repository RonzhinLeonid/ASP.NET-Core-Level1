using Microsoft.AspNetCore.Mvc;
using ViewModel;
using WebStore.Interfaces.Services;

namespace WebApplication1.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public SectionsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke(string SectionId)
        {
            var section_id = int.TryParse(SectionId, out var id) ? id : (int?)null;

            return View(new SelectableSectionsViewModel
            {
                Sections = GetSections(section_id, out var parent_section_id),
                SectionId = section_id,
                ParentSectionId = parent_section_id,
            });
        }

        private IEnumerable<SectionViewModel> GetSections(int? SectionId, out int? ParentSectionId)
        {
            ParentSectionId = null;

            var sections = _ProductData.GetSections();

            var parent_sections = sections.Where(s => s.ParentId is null).OrderBy(s => s.Order);

            var parent_sections_views = parent_sections
               .Select(s => new SectionViewModel
               {
                   Id = s.Id,
                   Name = s.Name,
               })
               .ToArray();

            foreach (var parent_section in parent_sections_views)
            {
                var childs = sections.Where(s => s.ParentId == parent_section.Id);
                foreach (var child_section in childs.OrderBy(s => s.Order))
                {
                    if (child_section.Id == SectionId)
                        ParentSectionId = parent_section.Id;

                    parent_section.ChildSections.Add(new()
                    {
                        Id = child_section.Id,
                        Name = child_section.Name,
                    });
                }
            }

            return parent_sections_views;
        }
    }
}
