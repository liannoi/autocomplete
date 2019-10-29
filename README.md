# Autocomplete

[//]: # (Badges)

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/3b0706a6d5ac4936bf5c5f6b3d579b3d)](https://www.codacy.com/manual/liannoi/autocomplete?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=liannoi/autocomplete&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/liannoi/autocomplete/badge)](https://www.codefactor.io/repository/github/liannoi/autocomplete)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://github.com/liannoi/autocomplete/blob/master/LICENSE)

[//]: # (Snapshot of the program)

![](https://github.com/liannoi/autocomplete/blob/master/res/screenshot.png)

[//]: # (Short description)

**The first multi-threaded asynchronous project.**

The goal of this project is to implement the functionality of the “F9 key”,
that is, a word hint on the entered letters. This project fulfills its direct
responsibility - not as well as large companies offer, because it searches for
words directly, and not through some special algorithms (which help to increase
the correctness of the proposed words).

[//]: # (Paragraphs)

## System requirements

| Visual Studio    | .NET Framework         |
|------------------|------------------------|
| 2017 (or higher) | 4.8                    |

## Build and Run

Standard steps for solutions with a WPF application. Except that you need to correctly load the dictionary, for this you should do the following:

- build a solution (so that the bin folder appears)
- go to the bin / Debug folder and create the Dictionaries folder
- in the root of the created folder, put the file ru-RU.dat (which is located in the res folder, the archive root folder)

## License

The repository is licensed by [Apache-2.0](https://github.com/liannoi/autocomplete/blob/master/LICENSE).

