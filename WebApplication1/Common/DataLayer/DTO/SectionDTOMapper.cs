﻿using System.Diagnostics.CodeAnalysis;

namespace DataLayer.DTO
{
    public static class SectionDTOMapper
    {
        [return: NotNullIfNotNull("section")]
        public static SectionDTO? ToDTO(this Section? section) => section is null
            ? null
            : new()
            {
                Id = section.Id,
                Name = section.Name,
                Order = section.Order,
                ParentId = section.ParentId,
            };

        [return: NotNullIfNotNull("section")]
        public static Section? FromDTO(this SectionDTO? section) => section is null
            ? null
            : new()
            {
                Id = section.Id,
                Name = section.Name,
                Order = section.Order,
                ParentId = section.ParentId,
            };

        public static IEnumerable<SectionDTO> ToDTO(this IEnumerable<Section>? sections) => sections?.Select(ToDTO)!;

        public static IEnumerable<Section> FromDTO(this IEnumerable<SectionDTO>? sections) => sections?.Select(FromDTO)!;
    }
}