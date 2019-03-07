﻿using System.Text.RegularExpressions;
using CatFactory.CodeFactory.Scaffolding;
using CatFactory.NetCore.CodeFactory;
using CatFactory.ObjectRelationalMapping;
using CatFactory.ObjectRelationalMapping.Programmability;

namespace CatFactory.NetCore
{
    public static class CSharpProjectExtensions
    {
        static CSharpProjectExtensions()
        {
        }

        public static string
            GetPropertyName<TProjectSettings>(this CSharpProject<TProjectSettings> project, string name)
            where TProjectSettings : class, IProjectSettings, new() => project.CodeNamingConvention.GetPropertyName
            (name);

        public static string GetPropertyName<TProjectSettings>(this CSharpProject<TProjectSettings> project,
            ITable table, Column column) where TProjectSettings : class, IProjectSettings, new()
            => table.Name == column.Name
                ? $"{project.GetPropertyName(column.Name)}1"
                : project.GetPropertyName(column.Name);

        public static string GetPropertyName<TProjectSettings>(this CSharpProject<TProjectSettings> project, IView view,
            Column column) where TProjectSettings : class, IProjectSettings, new()
            => view.Name == column.Name
                ? $"{project.GetPropertyName(column.Name)}1"
                : project.GetPropertyName(column.Name);

        public static string GetPropertyName<TProjectSettings>(this CSharpProject<TProjectSettings> project,
            Parameter parameter) where TProjectSettings : class, IProjectSettings, new()
            => project.GetPropertyName(parameter.Name);
    }
}
