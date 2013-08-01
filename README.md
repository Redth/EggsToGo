Eggs To Go
==========

Eggs To Go is a Xamarin Cross Platform mobile library for implementing Easter Egg gestures!

Features
--------
 - Konami and Mortal Kombat code
 - Create your own Custom sequences
 - Xamarin.iOS and Xamarin.Android support
 - Xamarin Component store
 


Getting Started - Xamarin.iOS
-------------------------
You can use the following code with any UIView you would like to recognize eggs/codes on (for example in a View Controller).  It will attach gesture listeners to the view you specify in the actor:

```csharp
//Create our new instance, specifying the UIView to recognize gestures on
var easter = new EggsToGo.Easter (this.View, new KonamiCode());

//Event for when a egg/code has been detected (eg: Konami Code)
easter.EggDetected += egg => Console.WriteLine("Egg: " + egg.Name);

//You can see each individual command as it happens too
easter.CommandDetected += cmd => Console.WriteLine("Command: " + cmd.Value);
```


 
Getting Started - Xamarin.Android
-------------------------
Android is a bit trickier than iOS, simply because recognizing gestures requires a MotionEvent of some sort.  Typically you would override the OnTouchEvent in an activity and pass that along to the Easter instance.  The Easter instance doesn't care where this information comes from, but it needs it in order to recognize gestures.

You can use the following code in the Activity you would like to support the gesture detection:

```csharp
public class MainActivity : Activity
{
	EggsToGo.Easter easter;
	
    protected override OnCreate(Bundle bundle)
    {
        base.OnCreate (bundle);
        
        SetContentView(Resource.Layout.Main);
        
        easter = new EggsToGo.Easter (new KonamiCode());
        
        //Event for when a egg/code has been detected (eg: Konami Code)
        easter.EggDetected += egg =>
            Toast.MakeText(this, egg.Name, ToastLength.Short).Show();
            
        //You can see each individual command as it happens too
        easter.CommandDetected += cmd =>
            Android.Util.Log.Debug("EggsToGo", "Commadn: " + cmd.Value);
    }
    
    public override bool OnTouchEvent(MotionEvent e)
    {
    	//IMPORTANT: You must pass this event on to the Easter class
        easter.OnTouchEvent(e);
        
        return base.OnTouchEvent(e);
    }
}
```


Default Egg Sequences
---------------------
By default I've included the Konami code and Mortal Kombat code:

- **Konami Code:** UP, UP, DOWN, DOWN, LEFT, RIGHT, LEFT, RIGHT, TAP, TAP
- **Mortal Kombat Code:** DOWN, UP, DOWN, DOWN, LEFT, RIGHT, LEFT, RIGHT, TAP, TAP


Custom Egg Sequences
--------------------
By default the Konami and Mortal Kombat codes are built in, but you may want to add your own sequences!

```csharp
var easyEgg = new CustomEgg("Easy")
    .WatchForSequence(Command.SwipeUp(), Command.SwipeDown(), Command.Tap());
    
var easter = new Easter(this.View, easyEgg);
```


Thanks
------
Thanks to Eight-Bot software for their original post on getting this working with Mono for Android: http://eightbot.com/writeline/developer/konami-code-detection-with-mono-for-android/

This was definitely my inspiration for making this simple component!


License
-------
The MIT License (MIT)

Copyright (c) 2013 Jonathan Dick

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


