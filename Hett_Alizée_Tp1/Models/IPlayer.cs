namespace Hett_Alizée_Tp1.Models
{
    internal interface IPlayer
    {
        Spaceship DefaultSpaceship { get; set; }
        string Name { get; }
        string Alias { get; }
    }
}