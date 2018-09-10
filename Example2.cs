using System;

interface IVideoSource
{
    string GetTvGuide();
    string PlayVideo();
}

class LocalCabelTv : IVideoSource
{
    const string SOURCE_NAME = "Local Cabel TV";

    string IVideoSource.GetTvGuide()
    {
        return string.Format("Getting TV guide from - {0}", SOURCE_NAME);
    }

    string IVideoSource.PlayVideo()
    {
        return string.Format("Playing - {0}", SOURCE_NAME);
    }
}

class LocalDishTv : IVideoSource
{
    const string SOURCE_NAME = "Local DISH TV";

    string IVideoSource.GetTvGuide()
    {
        return string.Format("Getting TV guide from - {0}", SOURCE_NAME);
    }

    string IVideoSource.PlayVideo()
    {
        return string.Format("Playing - {0}", SOURCE_NAME);
    }
}

class IPTvService : IVideoSource
{
    const string SOURCE_NAME = "IP TV";

    string IVideoSource.GetTvGuide()
    {
        return string.Format("Getting TV guide from - {0}", SOURCE_NAME);
    }

    string IVideoSource.PlayVideo()
    {
        return string.Format("Playing - {0}", SOURCE_NAME);
    }
}

class MySuperSmartTV
{
    IVideoSource currentVideoSource = null;

    public IVideoSource VideoSource
    {
        get
        {
            return currentVideoSource;
        }
        set
        {
            currentVideoSource = value;
        }
    }

    public void ShowTvGuide()
    {
        if (currentVideoSource != null)
        {
            Console.WriteLine(currentVideoSource.GetTvGuide());
        }
        else
        {
            Console.WriteLine("Please select a Video Source to get TV guide from");
        }
    }

    public void PlayTV()
    {
        if (currentVideoSource != null)
        {
            Console.WriteLine(currentVideoSource.PlayVideo());
        }
        else
        {
            Console.WriteLine("Please select a Video Source to play");
        }
    }
}

class SuperSmartTvController
{
    static void Main(string[] args)
    {
        MySuperSmartTV myTv = new MySuperSmartTV();

        Console.WriteLine("Select A source to get TV Guide and Play");
        Console.WriteLine("1. Local Cable TV\n2. Local Dish TV\n3. IP TV");

        ConsoleKeyInfo input = Console.ReadKey();

        // Let us see what user has selected and select the video source accrodingly
        switch (input.KeyChar)
        {
            case '1':
                myTv.VideoSource = new LocalCabelTv();
                break;

            case '2':
                myTv.VideoSource = new LocalDishTv();
                break;

            case '3':
                myTv.VideoSource = new IPTvService();
                break;
        }

        Console.WriteLine(); //some whitespace on output for readability

        //Let us show the TV guide from selected source
        myTv.ShowTvGuide();

        //Let us now play the selected TV source.
        myTv.PlayTV();

        Console.WriteLine(); //some whitespace on output for readability
    }
}