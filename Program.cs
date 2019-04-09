using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JsonData;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            System.Console.WriteLine("That Guy From Mount Vernon");
            IEnumerable<Artist> thatGuyFromMtVernon = Artists.Where(a => a.Hometown == "Mount Vernon");
            foreach(var a in thatGuyFromMtVernon)
            {
                System.Console.WriteLine("Name: "+ a.ArtistName + " Age: "+ a.Age);
            }

            //Who is the youngest artist in our collection of artists?
            // int yAge = Artists.Min(artist => artist.Age);
            System.Console.WriteLine("Youngest Gun");
            IEnumerable<Artist> youngestArtist = Artists.Where(artist => artist.Age == Artists.Min(a => a.Age));
            foreach(var a in youngestArtist)
            {
                System.Console.WriteLine("Name: "+ a.ArtistName + " Age: "+ a.Age);
            }
            //Display all artists with 'William' somewhere in their real name
            System.Console.WriteLine("Billys");
            IEnumerable<Artist> billys = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach(var a in billys)
            {
                System.Console.WriteLine("Name: "+ a.ArtistName + " Age: "+ a.Age);
            }
            // //Display the 3 oldest artist from Atlanta
            System.Console.WriteLine("Fossils");
            IEnumerable<Artist> fossils = Artists.OrderByDescending(artist => artist.Age)
                .Take(3);
            foreach(var a in fossils)
            {
                System.Console.WriteLine("Name: "+ a.ArtistName + " Age: "+ a.Age);
            }    
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            System.Console.WriteLine("Non New Yorkers");
            IEnumerable<string> notApples = Artists.Where(artist => artist.Hometown != "New York City")
                .Join(Groups,
                    artist => artist.GroupId,
                    group => group.Id,
                    (artists, group) =>
                    {
                        return group.GroupName;
                    }).Distinct().ToArray();
            foreach(var member in notApples)
            {
                System.Console.WriteLine(member);
            }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            System.Console.WriteLine("Wu-Tang Clan");
            IEnumerable<string> wuTangClan = Groups
                .Where(group => group.GroupName == "Wu-Tang Clan")
                .Join(Artists,
                    group => group.Id,
                    artist => artist.GroupId,
                    (group, artist) =>
                    {
                        return artist.ArtistName+ " "+artist.RealName+ " "+ group.GroupName;
                    });
            foreach(var member in wuTangClan)
            {
                System.Console.WriteLine(member);
            }
	        // Console.WriteLine(Groups.Count);
        }
    }
}
