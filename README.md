# Photoshop

**The application allows the user to edit the color and angle of the image**
<br />

![](/examples/photo-editing.gif "Photoshop")

**Color**  

The application changes the color of the image by changing the values of one RGB channel.

**Angle**

In two-dimensional space, a rotation is described by one angle θ with the following linear transformation matrix in the Cartesian coordinate system ([original source](https://ru.wikipedia.org/wiki/%D0%9C%D0%B0%D1%82%D1%80%D0%B8%D1%86%D0%B0_%D0%BF%D0%BE%D0%B2%D0%BE%D1%80%D0%BE%D1%82%D0%B0)):  

![](/examples/formula.png)  

![](/examples/core.png "")

## Dependencies

Maze generator uses gnuplot (with a system call `gnuplot`) to render png mazes.
So make sure that `gnuplot 5.0+` is installed with `pngcairo` terminal support
and is in the path if you wish to use png.

The code is written in C++ 11, you will need a not-too-ancient C++ compiler to
build it.

## Installation

```
cd src; make
```

## Usage

```
Usage: mazegen [--help] [-m <maze type>] [-a <algorithm type>]
               [-s <size> | -w <width> -h <height>]
               [-t <output type] [-o <output prefix>]

Optional arguments
  --help  Show this message and exit
  -m      Maze type
          0: Rectangular (default)
          1: Hexagonal (triangular lattice)
          2: Honeycomb
          3: Circular
          4: Circular (triangular lattice)
          5: User-defined
  -a      Algorithm type
          0: Kruskal's algorithm (default)
          1: Depth-first search
          2: Breadth-first search
          3: Loop-erased random walk
          4: Prim's algorithm
  -s      Size (non-rectangular mazes, default: 20)
  -w,-h   Width and height (rectangular maze, default: 20)
  -t      Output type
          0: svg output (default)
          1: png output using gnuplot (.plt) intermediate 
  -o      Prefix for .svg, .plt and .png outputs (default: maze)
```

## Issues

The arcs in the circular mazes are plotted as parametric curves in gnuplot, and
png can take quite long to render for large mazes.
