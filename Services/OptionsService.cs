using BlazorJob.Data;
using BlazorJob.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Services
{
    public class OptionsService : StandartModelService<Option>
    {
        public OptionsService(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {
        }

        public MenuForDraw GetMenu()
        {
            var menu = new MenuItem
            {
                Title = "Main menu",
                Icon = "None",
                Key = "mainmenu",
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Title = "Home",
                        Key = "index",
                        Icon = "home",
                        RouterMatch = NavLinkMatch.All,
                        RouterLink = "/"
                    },
                    new MenuItem
                    {
                        Title = "menu1",
                        Key = "menu1",
                        RouterLink = "/404",

                        Items = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Title = "submenu1",
                                Key = "submenu1",
                                RouterLink = "/test",
                                
                            },
                            new MenuItem
                            {
                                Title = "counter",
                                Key = "counter",
                                RouterLink = "/counter",
                            },
                            new MenuItem
                            {
                                Title = "fetchdata",
                                Key = "fetchdata",
                                RouterLink = "/fetchdata",
                            },
                            new MenuItem
                            {
                                Title = "nodered",
                                Key = "nodered",
                                RouterLink = "/nodered",
                            },
                            new MenuItem
                            {
                                Title = "items",
                                Key = "items",
                                RouterLink = "/items",
                            },
                            new MenuItem
                            {
                                Title = "edit",
                                Key = "edit",
                                RouterLink = "/edit",
                            },

                            new MenuItem
                            {
                                Title = "options",
                                Key = "options",
                                RouterLink = "/options",
                            },
                            new MenuItem
                            {
                                Title = "editoption",
                                Key = "editoption",
                                RouterLink = "/editoption",
                            },
                            new MenuItem
                            {
                                Title = "meta",
                                Key = "meta",
                                RouterLink = "/meta",
                            },
                            new MenuItem
                            {
                                Title = "editmeta",
                                Key = "editmeta",
                                RouterLink = "/editmeta",
                            },
                        }
                    }
                }
            };

            return new MenuForDraw
            {
                menu = menu,
                deafultOpenKeys = new List<string> { "menu1" },
                defaultSelectedKeys = new List<string> { "index" },
            };
        }
    }

    public class MenuItem
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public List<MenuItem> Items { get; set; }
        public string RouterLink { get; set; }
        public NavLinkMatch RouterMatch { get; set; } = NavLinkMatch.Prefix;


    }

    public class MenuForDraw
    {
        public MenuItem menu{ get; set; }

        public List<string> defaultSelectedKeys { get; set; }
        public List<string> deafultOpenKeys { get; set; }

    }
}
