# TinyProcessProfiler
Tiny console app that runs a process a certain number of times and returns stats such as average/fastest/slowest running time.
[Download](https://github.com/kblok/TinyProcessProfiler/releases/download/v1.0/TinyProcessProfiler.zip)

## Usage

```
C:\publish>TinyProcessProfiler.exe "<Process>" <Iterations>
```

## Example

```
C:\publish>TinyProcessProfiler.exe "cd ." 5
Running iteration: 1
Running iteration: 2
Running iteration: 3
Running iteration: 4
Running iteration: 5
FINISHED
Fastest run:             9 milliseconds
Slowest run:             13 milliseconds
Avg run:                 11 milliseconds
Std deviation:           0
```
