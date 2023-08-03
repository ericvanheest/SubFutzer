SubFutzer quick help document

IMPORTANT:

SubFutzer is written for the Microsoft .NET environment, and requires
the .NET runtime libraries in order to operate.  If you do not have
these files, you can download the .NET redistributable package from
http://www.microsoft.com

NOTE:  SubFutzer currently supports only the SubRip subtitle format
       (*.srt files).  This is because these are the only files I
       tend to use, and since it's easy to convert from one format to
       another with other programs, I didn't care to add other arbitrary
       formats.  If you'd like one in particular, feel free to let me
       know and I'd be happy to add it (see "Contact Information").

===========================================================================
VirtualDub Job Processing
===========================================================================

SubFutzer is a relatively uncomplicated program that was originally written
to solve one particular problem - splitting subtitle files from a single
DVD containing several episodes of a show into separate subtitle files that
contain proper timecodes.

Since I use VirtualDub to split files, I decided to make SubFutzer read a
VirtualDub .jobs file directly, and use the information there to generate
the proper split files automatically.  All that you need to do in order to
use this functionality is:

1.  Use VirtualDub to save sections of the video to individual episodes,
    using the "Set selection start" and "Set selection end" functions, and
    saving each selection to its own file.  Use the "Add operation to
    job list and defer processing" command on the "Save AVI" dialog to
    create the job list.

2.  Use the SubFutzer options dialog to set the location of VirtualDub's
    VirtualDub.jobs file (usually something like "C:\Program
    Files\VirtualDub\VirtualDub.jobs).

3.  Load the subtitle file for the entire video into SubFutzer.

4.  Use the "Process default .jobs file" from the Action menu to scan the 
    VirtualDub.jobs file and produce separate subtitle files for each job.

5.  The new subtitle files will be placed in the same directory as the
    output file given in the .jobs file.

NOTE:  Due to the way VirtualDub's "SetRange()" command works, the
       original AVI file must be present in order for each subtitle
       section to terminate properly (SubFutzer must be able to
       determine the length of the AVI).  If the AVI is not present or
       otherwise not readable, the subtitle sections will start in the
       correct place and be offset properly, but will require manual
       trimming of the end of the file.

========================================
Commands available via the "Action" menu
========================================

-----------
Renumbering
-----------

The "Renumber" command parses the subtitles and ensures that the index
numbers are consistent.  Most operations (delete, merge, etc) will
take care of this automatically, but when loading a new file, the
original indices will be preserved unless you select the "Renumber"
command (or perform another operation, like a merge, that forces a
renumbering).  If the original file has out-of-sequence index numbers,
you will be warned via a message on the status bar.

------------------------------
Collapse sequential duplicates
------------------------------

This option will convert any two sequential subtitles (that is, the ending
time of the first subtitle is the same as the starting time of the next
one) that have identical text into a single subtitle with a duration equal
to the sum of the original two.

---------------------------
Remove short duration items
---------------------------

This will allow you to automatically delete any subtitles that have a
duration less than a specified amount.

-------------------------------------
Remove intra-subtitle duplicate lines
-------------------------------------

This will remove duplicate lines from individual subtitles.  Brackets will
be ignored during the comparison, so a subtitle that was this:

	That'll do it.
	Hooray!
	[ Hooray! ]

will become this:

	That'll do it.
	Hooray!

--------------------------------
Move subtitles up/down one index
--------------------------------

This option will shift the text of the range of subtitles to the next item
in that range, so a set like this:

4	10.000	10.500	0.500	Subtitle 1
5	12.000	12.500	0.500	Subtitle 2
6	15.000	15.500	0.500	Subtitle 3
7	19.000	19.500	0.500	Subtitle 4

Will become this when shifted down one index:

4	10.000	10.500	0.500	Subtitle 1
5	12.000	12.500	0.500	Subtitle 1
6	15.000	15.500	0.500	Subtitle 2
7	19.000	19.500	0.500	Subtitle 3

As you can see, the last subtitle is lost during the shift.  The reverse
will happen if you pick "shift up one index" and you will lose the first
subtitle in the range.

===========================================================================
Other Functionality
===========================================================================

SubFutzer also includes several other functions intended as a
convenience.  These function are:

-------------
Time shifting
-------------

By setting the time shift dropdown to one of "Shift backwards by,"
"Shift forwards by," or "Set first item to," and pressing the "Go"
button next to the time control, you will shift the entire set of
subtitles (or the selected subtitles only, depending on the setting of
the combo box above these controls).

  Shift Forward:  Moves all affected subtitles forward in time by the
                  amount specified in the time control.

  Shift Backward: Same as "shift forward," but in the opposite direction.

  Set first item: Sets the first item (or first selected item), to the
                  value specified by the time control, and shifts all
                  other (or all other selected) items accordingly.

A fourth option is available, "Expand last item to," which sets the
last item (or last selected item) to the specified value.  This
operation differs from the previous three in that it actually expands
(or contracts, if the time value is smaller than the original) the
time between the first subtitle and the last one.  This is useful to
use if a set of subtitles becomes more and more out-of-sync as a video
progresses.

"Expand By" and "Contract By" also use this adjustment method, but
these two use a relative amount of increase or decrease rather than an
absolute value for the last item.

------------
Line lengths
------------

The "Set maximum line length" function can be used to "wrap" long
subtitles at a certain character length.  Pressing the "Go" button will
ensure that each subtitle (or each selected subtitle, depending on the
setting of the combo box) will have a maximum line length of the value
specified.  Lines will be wrapped at space (0x20) characters only; if
there are no spaces in a line, the line will not be wrapped.

Merging multiple-line subtitles into a single line can be accomplished
with a press of the "Merge all lines" button.  The "Keep newlines"
checkbox controls whether this operation includes lines that begin with
a "[" character or not (when subtitles are merged, brackets are added to
lines that were actually merged into a single subtitle).

----------------------
Merging subtitle files
----------------------

If you find yourself with two (or more) subtitle files that are part of
the same video (as can happen when using SubRip to extract multiple
"colors" of subtitles from a set of VOB files), you can use SubFutzer's
"merge" function to create a single set of subtitles out of the set.
Simply load in the "main" set of subtitles, select the "Merge" option
from the File menu, and pick the seconary subtitle set.  Subfutzer will
merge the two files, merging lines if necessary (if two subtitle times
overlap).  If an overlap is merges, the secondary file's text will be
included in brackets in order to preserve readability, since the text
would originally have likely been in two separate colors.  The effect
looks like this:

     When power collides with power,
     [ Chikara to chikara butsukareba, ]

-------------------------
Editing a single subtitle
-------------------------

When a subtitle is selected, you may edit its text, start time, and stop
time directly using the controls in the lower right.  Press the "Update"
button to confirm the change.

------------------
Searching for text
------------------

Control+F will bring up the search window, from which you may search for
text within subtitles.  Options are available for case-sensitivity,
wraparound searching, and reversing the search direction.

---------------------
Deleting and Cropping
---------------------

When a group of subtitles is selected, you can delete them by
right-clicking and selecting "Delete selected items" or by pressing the
"Delete" key on the keyboard.  You may crop away everything except the
selected subtitles by choosing "Delete all but selected items" from the
context menu.

----
Undo
----

Most actions can be undone by selecting the Undo menu item or pressing
Control+Z.  There is currently only one level of undo, and selecting
"Undo" a second time will re-do the operation.

===========================================================================
Scripts
===========================================================================

SubFutzer supports an extremely limited scripting language that you can
access via the command line:

SubFutzer.exe -f ScriptFile.txt

The script file is just a list of commands, some of which take arguments.
The current list of commands is:

close             Close the current .srt file
jobs <file>       Process the given VirtualDub .jobs file
merge <file>      Merge the current file with the specified one
open <file>       Open the specified .srt file
quit              Exits SubFutzer
save <file>       Save the current file to the specified file name
save              Save the current file to its original file name
shiftback <time>  Shifts the current file back <time> seconds
shiftfwd <time>   Shifts the current file forward <time> seconds
setfirst <time>   Sets the first subtitle to time index <time>
expandlast <time> Expands the subtitles so that the last one is at <time>
expandby <time>   Expands all of the subtitles so that the last one is
                  later by <time> units
contractby <time> Contracts all of the subtitles so that the last one is
                  earlier by <time> units
lengthenby <time> Lenghtens the duration of each subtitle by <time> units
shortedby <time>  Shortens the duration of each subtitle by <time> units
extract <t1> <t2> Deletes subtitles outside the range <t1> to <t2>
extract <file>    Extracts multiple ranges based on a list of times in <file> 

(a <time> value is identical to what you can enter in the text boxes of
the main form, such as "1:1.4" or ".5")

For example, a script might include these commands:

open Episode1-Color_1.srt
merge Episode1-Color_2.srt
save Episode1-Merged.srt
open Episode2-Color_1.srt
merge Episode2-Color_2.srt
save Episode2-Merged.srt
quit

===========================================================================
Copyright Information
===========================================================================

SubFutzer is Copyright (C) 2002 by Eric VanHeest.  This program is
intended as freeware, and may be copied and distributed as such.  The
source code is included as a reference for the curious, and is not
intended as an example of proper style or implementation.

-------------------
Contact Information
-------------------

The author's e-mail address is edv_ws@vanheest.org.  Comments, questions,
and criticisms are all welcomed.  If you would like a feature added,
please don't hesitate to mention it.  If you notice a bug, please tell
me about it!

