namespace Kitty
{
class cat
{
    public string catName;
    private int catAge;

    public int CatAge
    {
        get 
        {
            return catAge;
        }
        set 
        {
            catAge = value;
        }
    }

    public override string ToString()
    {
        return $"{catName} {catAge} год";
    }
}
}