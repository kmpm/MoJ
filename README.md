MoJ
==================
Mouse and keyboard emulation using Joystick inputs
![Logo](doc/MoJ.png)

Story
-----------
This sofware were written because of a friend of mine in need.
Due to a medical condition it's incredibly hard for him to click on a mouse or type on a 
keyboard using his fingers. Moving a mouse using his arms and using his feet for pressing buttons is ok.
As an aid he got a small device called JoyBox which is a small box that you connect 
to your computer and turns up as a mouse. To this box you can connect switches and 
stuff that in this case were used with the feet.

The software that came along did have one major drawback. Because of my friends interests 
( and I would say previous occupation ) he liked to to CAD work and the software he used 
worked best with a 3 button mouse, and the JoyBox software didn't support the third button. 
We also had difficulties to make it work as a normal mouse button. Click was ok, but not 
press and hold. As his medical condition have gotten worse he is also finding it more and 
more difficult to press Ctrl or Shift on the keyboard while clicking so that keyboard 
support was needed as well. 

Features
--------
So, this software listens for Joystick input (any joystick should work) and lets 
you configure Tasks with one or more actions in them that is triggered in various ways.

The actions can be for keyboard be of the type key down/up/press or text input. Most 
keycodes are supported. Mouse actions are down/up/click for left, middle and right buttons.
All actions can be followed by a delay which is set in milliseconds.

Actions are grouped into tasks so a task can be for example. To write "Hello World!", press [Enter] 
and then do a right click on the mouse, all in sequence.

For the moment only digital mouse buttons are supported, and as many of them as the 
joystick has. There is no software limit (DirectX might have some but not that I know of) 
on how many buttons you can have.
To each button you can assign 2 tasks. How these are executed is somewhat different 
depending on how you set the button _mode_.
Each button can have one of two modes, trigger or toggle.
In the trigger mode a task is executed on button down, and the other when the 
button is released. This could be for example, middle mouse button down and up.
The toggle mode activates the first task when the button is pressed and the second 
task when it's pressed again.
So for example on the first press you might have a task that simulate a "shift down" on the 
keyboard and when the same button is pressed again you can have "shift up" to release the button.

Installation
------------
You basically have to options, either compile and run it yourself or
download from https://bintray.com/kmpm/winforms/MoJ .
That download should be fairly ok but as stated in the license...

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

Future
------
* Implement more joystick functions like sliders, PoV etc 
  for input.
* Mouse movement output
* Somehow using the analog values from the joystick 
  in the actions somehow.
* Better documentation.


Techical
--------
* Built using _.NET 4.0 Client Profile_ 
* DirectX is used to capture the Joystick inputs. 
  _SharpDX_ is the managed code library used to make 
  it work somewhat easier. ( http://www.sharpdx.org )
* For saving some time when it came to the output a
  library called _InputSimulator_ was used.
  ( http://inputsimulator.codeplex.com/ ) 


License
-------
SharpDX and InputSimulator have their own licenses but..

MoJ is an open-source project, free of charge available 
under the following MIT License:

Copyright (c) 2013 MoJ - Peter Magnusson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

