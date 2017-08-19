using EventsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventsApi.Controllers
{
    public class EventsController : ApiController
    {
        #region MyEventsPreData
        static List<EventModel> _events = new List<EventModel>() {
            new EventModel {
                Id =  1,
                Name =  "Angular Connect",
                Date =  new DateTime(2036,9,26),
                Time =  "10:00 am",
                Price =  599.99,
                ImageUrl =  "/app/assets/images/angularconnect-shield.png",
                Location =  new LocationModel {
                    Address =  "1057 DT",
                    City =  "London",
                    Country =  "England"
                        },
                Sessions = new List<SessionModel> {
                    new SessionModel
                    {
                        Id =  1,
                        Name =  "Using Angular 4 Pipes",
                        Presenter =  "Peter Bacon Darwin",
                        Duration = 1,
                        Level = "Intermediate",
                        Abstract =  @"Learn all about the new pipes in Angular 4, both
                  how to write them, and how to get the new AI CLI to write
                  them for you.Given by the famous PBD, president of Angular
                 University(formerly Oxford University)",
                        Voters = new string[] {"bradgreen", "igorminar", "martinfowler"}
                    },
                   new SessionModel {
                        Id =  2,
                        Name =  "Getting the most out of your dev team",
                        Presenter =  "Jeff Cross",
                        Duration = 1,
                        Level = "Intermediate",
                        Abstract =  @"We all know that our dev teams work hard, but with
                  the right management they can be even more productive, without
                  overworking them.In this session I'll show you how to get the 
                  best results from the talent you already have on staff.",
                        Voters = new string[] {"johnpapa", "bradgreen", "igorminar", "martinfowler"}
                    },
                   new SessionModel {
                        Id =  3,
                        Name =  "Angular 4 Performance Metrics",
                        Presenter =  "Rob Wormald",
                        Duration = 2,
                        Level = "Advanced",
                        Abstract =  @"Angular 4 Performance is hot.In this session, we'll see 
                  how Angular gets such great performance by preloading data on
                  your users devices before they even hit your site using the 
                  new predictive algorithms and thought reading software
                  built into Angular 4.",
                        Voters = new string[] {}
                    },
                   new SessionModel {
                        Id =  4,
                        Name =  "Angular 5 Look Ahead",
                        Presenter =  "Brad Green",
                        Duration = 2,
                        Level = "Advanced",
                        Abstract =  @"Even though Angular 5 is still 6 years away, we all want
                  to know all about it so that we can spend endless hours in meetings
                  debating if we should use Angular 4 or not.This talk will look at
                  Angular 6 even though no code has yet been written for it.We'll 
                  look at what it might do, and how to convince your manager to
                  hold off on any new apps until it's released",
                        Voters = new string[] {}
                    },
                   new SessionModel {
                        Id =  5,
                        Name =  "Basics of Angular 4",
                        Presenter =  "John Papa",
                        Duration = 2,
                        Level = "Beginner",
                        Abstract =  @"it's time to learn the basics of Angular 4. This talk 
                  will give you everything you need to know about Angular 4 to
                  get started with it today and be building UI's for your self 
                  driving cars and butler-bots in no time.",
                        Voters = new string[] {"bradgreen", "igorminar"}
                    }
                }
            },
            new EventModel {
                Id =  2,
                Name =  "ng-nl",
                Date =  new DateTime(2036,9,26),
                Time =  "9:00 am",
                Price =  950,
                ImageUrl =  "/app/assets/images/ng-nl.png",
                OnlineUrl ="http://ng-nl.org",
                Sessions = new List<SessionModel> {
                    new SessionModel
                    {
                        Id =  1,
                        Name =  "Testing Angular 4 Workshop",
                        Presenter =  "Peter Bacon Darwin",
                        Duration = 1,
                        Level = "Beginner",
                        Abstract =  @"Learn all about the new pipes in Angular 4, both
                  how to write them, and how to get the new AI CLI to write
                  them for you.Given by the famous PBD, president of Angular
                 University(formerly Oxford University)",
                        Voters = new string[] {"bradgreen", "igorminar", "martinfowler"}
                    },
                   new SessionModel {
                        Id =  2,
                        Name =  "Angular 4 and Firebase",
                        Presenter =  "Jeff Cross",
                        Duration = 1,
                        Level = "Intermediate",
                        Abstract =  @"We all know that our dev teams work hard, but with
                  the right management they can be even more productive, without
                  overworking them.In this session I'll show you how to get the 
                  best results from the talent you already have on staff.",
                        Voters = new string[] {"johnpapa", "bradgreen", "igorminar", "martinfowler"}
                    },
                   new SessionModel {
                        Id =  3,
                        Name =  "Reading the Angular 4 Source",
                        Presenter =  "Rob Wormald",
                        Duration = 2,
                        Level = "Advanced",
                        Abstract =  @"Angular 4 Performance is hot.In this session, we'll see 
                  how Angular gets such great performance by preloading data on
                  your users devices before they even hit your site using the 
                  new predictive algorithms and thought reading software
                  built into Angular 4.",
                        Voters = new string[] {}
                    },
                   new SessionModel {
                        Id =  4,
                        Name =  "Hail to the Lukas",
                        Presenter =  "Brad Green",
                        Duration = 2,
                        Level = "Advanced",
                        Abstract =  @"Even though Angular 5 is still 6 years away, we all want
                  to know all about it so that we can spend endless hours in meetings
                  debating if we should use Angular 4 or not.This talk will look at
                  Angular 6 even though no code has yet been written for it.We'll 
                  look at what it might do, and how to convince your manager to
                  hold off on any new apps until it's released",
                        Voters = new string[] {}
                    }
                }
            },
            new EventModel {
                Id =  3,
                Name =  "ng-conf 2037",
                Date =  new DateTime(2037,4,5),
                Time =  "9:00 am",
                Price =  759.00,
                ImageUrl =  "/app/assets/images/ng-conf.png",
                Location =  new LocationModel {
                    Address =  "The Palatial America Hotel",
                    City =  "Salt Lake City",
                    Country =  "USA"
                },
                Sessions = new List<SessionModel> {
                 new SessionModel   {
                        Id =  1,
                        Name =  "How Elm Powers Angular 4",
                        Presenter =  "Murphy Randle",
                        Duration = 2,
                        Level = "Intermediate",
                        Abstract =  @"We all know that Angular is written in Elm, but did you
                  know how the source code is really written? In this exciting look
                  into the internals of Angular 4, We'll see exactly how Elm powers
                  the framework, and what you can do to take advantage of this knowledge.",
                        Voters = new string[] {"bradgreen", "martinfowler", "igorminar"}
                    },
                    new SessionModel  {
                        Id =  2,
                        Name =  "Angular and React together",
                        Presenter =  "Jamison Dance",
                        Duration = 2,
                        Level = "Intermediate",
                        Abstract =  @"React v449.6 has just been released.Let's see how to use
                  this new version with Angular to create even more impressive applications.",
                        Voters = new string[] {"bradgreen", "martinfowler"}
                    },
                      new SessionModel{
                        Id =  3,
                        Name =  "Redux Woes",
                        Presenter =  "Rob Wormald",
                        Duration = 1,
                        Level = "Intermediate",
                        Abstract =  @"Everyone is using Redux for everything from Angular to React to
                  Excel macros, but you're still having trouble grasping it? We'll take a look
                  at how farmers use Redux when harvesting grain as a great introduction to
                  this game changing technology.",
                        Voters = new string[] {"bradgreen", "martinfowler", "johnpapa"}
                    },
                      new SessionModel{
                        Id =  4,
                        Name =  "ng-wat again!!",
                        Presenter =  "Shai Reznik",
                        Duration = 1,
                        Level = "Beginner",
                        Abstract =  @"Let's take a look at some of the stranger pieces of Angular 4,
                  including neural net nets, Android in Androids, and using pipes with actual pipes.",
                        Voters = new string[] {"bradgreen", "martinfowler", "igorminar", "johnpapa"}
                    },
                      new SessionModel{
                        Id =  5,
                        Name =  "Dressed for Success",
                        Presenter =  "Ward Bell",
                        Duration = 2,
                        Level = "Beginner",
                        Abstract =  @"Being a developer in 2037 is about more than just writing bug-free code.
                  You also have to look the part. In this amazing expose, Ward will talk you through
                  how to pick out the right clothes to make your coworkers and boss not only
                  respect you, but also want to be your buddy.",
                        Voters = new string[] {"bradgreen", "martinfowler"}
                    },
                      new SessionModel{
                        Id =  6,
                        Name =  "These aren't the directives you're looking for",
                        Presenter =  "John Papa",
                        Duration = 2,
                        Level = "Intermediate",
                        Abstract =  @"Coinciding with the release of Star Wars Episode 18, this talk will show how
                  to use directives in your Angular 4 development while drawing lessons from the new movie,
                  featuring all your favorite characters like Han Solo's ghost and Darth Jar Jar.",
                        Voters = new string[] { "bradgreen", "martinfowler" }
                    },
                }
            },
            new EventModel{
                Id =  4,
                Name =  "UN Angular Summit",
                Date =  new DateTime(2037,1,15),
                Time =  "8:00 am",
                Price =  800.00,
                ImageUrl =  "/app/assets/images/basic-shield.png",
                Location =  new LocationModel {
                    Address =  "The UN Angular Center",
                    City =  "New York",
                    Country =  "USA"
                },
                Sessions = new List<SessionModel> {
                 new SessionModel   {
                        Id =  1,
                        Name =  "Diversity in Tech",
                        Presenter =  "Sir Dave Smith",
                        Duration = 2,
                        Level = "Beginner",
                        Abstract =  @"Yes, we all work with cyborgs and androids and Martians, but
                  we probably don't realize that sometimes our internal biases can make it difficult for
                  these well-designed coworkers to really feel at home coding alongside us.This talk will
                  look at things we can do to recognize our biases and counteract them.",
                        Voters = new string[] { "bradgreen", "igorminar" }
                    },
                    new SessionModel {
                        Id =  2,
                        Name =  "World Peace and Angular",
                        Presenter =  "US Secretary of State Zach Galifianakis",
                        Duration = 2,
                        Level = "Beginner",
                        Abstract =  @"Angular has been used in most of the major peace brokering that has
                  happened in the last decade, but there is still much we can do to remove all
                  war from the world, and Angular will be a key part of that effort.",
                        Voters = new string[] {"bradgreen", "igorminar", "johnpapa"}
                    },
                    new SessionModel {
                        Id =  3,
                        Name =  "Using Angular with Androids",
                        Presenter =  "Dan Wahlin",
                        Duration = 3,
                        Level = "Advanced",
                        Abstract =  @"Androids may do everything for us now, allowing us to spend all day playing
                  the latest Destiny DLC, but we can still improve the massages they give and the handmade
                  brie they make using Angular 4. This session will show you how.",
                        Voters = new string[] {"igorminar", "johnpapa"}
                    },
                }
            },
            new EventModel {
                Id =  5,
                Name =  "ng-vegas",
                Date =  new DateTime(2037,1,5),
                Time =  "9:00 am",
                Price =  400.00,
                ImageUrl =  "/app/assets/images/ng-vegas.png",
                Location =  new LocationModel {
                    Address =  "The Excalibur",
                    City =  "Las Vegas",
                    Country =  "USA"
                },
                Sessions = new List<SessionModel> {
                  new SessionModel  {
                        Id =  1,
                        Name =  "Gambling with Angular",
                        Presenter =  "John Papa",
                        Duration = 1,
                        Level = "Intermediate",
                        Abstract =  @"No, this talk isn't about slot machines.We all know that
                  Angular is used in most waiter-bots and coke vending machines, but
                  did you know that was also used to write the core engine in the majority
                  of voting machines? This talk will look at how all presidential elections
                  are now determined by Angular code.",
                        Voters = new string[] { "bradgreen", "igorminar" }
                    },
                    new SessionModel {
                        Id =  2,
                        Name =  "Angular 4 in 60ish Minutes",
                        Presenter =  "Dan Wahlin",
                        Duration = 2,
                        Level = "Beginner",
                        Abstract =  @"Get the skinny on Angular 4 for anyone new to this great new technology.
                  Dan Wahlin will show you how you can get started with Angular in 60ish minutes,
                  guaranteed!",
                        Voters = new string[] {"bradgreen", "igorminar", "johnpapa"}
                    }
                }

            }

        };
        #endregion

        public List<EventModel> Get()
        {
            return _events;
        }
        public EventModel Get(int id)
        {
            return _events.FirstOrDefault(m=>m.Id == id);
        }
        
        public bool Post(EventModel model)
        {
            if (model.Id == 0)
            {
                model.Id = _events.Max(m => m.Id) + 1;
                _events.Add(model);
            }
            else
            {
                var x = _events.First(m => m.Id == model.Id);
                x = model;
            }
            return true;
        }
        public bool Put(EventModel model)
        {
            return true;
        }
        public bool Delete(int id)
        {
            return true;
        }
      


    }
}
