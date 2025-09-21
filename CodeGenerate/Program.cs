// See https://aka.ms/new-console-template for more information
using AutoMapper;
using CodeGenerate;
using Common.Util;
using Microsoft.Extensions.Logging;
using Model.Attributes;
using Model.Table.Authorize;
using Scriban;
using System.Reflection;

MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
{
    config.AddProfile<MapperConfig>();
});

mapperConfiguration.CreateMapper();