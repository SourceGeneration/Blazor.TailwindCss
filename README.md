# Blazor.TailwindCss

[![NuGet](https://img.shields.io/nuget/vpre/SourceGeneration.Blazor.TailwindCss.svg)](https://www.nuget.org/packages/SourceGeneration.Blazor.TailwindCss)

`SourceGeneration.Blazor.TailwindCss` dynamically generates the `tailwind.css` file by parsing class references in Razor files through MSBuild tasks after compilation.

Scans all `*.razor` files, extracts class attribute values from HTML elements, supports:

```html
<div class="mt-2"></div>
<MudText Class="p-2"></MudText>
```

Scans all `*.cs` files, extracts class from `CssBuilder.Class("...")`
```c#
public TypographyColors TypographyDark { get; set; } = new TypographyColors
    {
        Primary = CssBuilder.Class("text-white"),
        Secondary = CssBuilder.Class("text-gray-300"),
        Highlight = CssBuilder.Class("text-white"),
    };
```

The `tailwind.css` file will be generated in the `wwwroot` folder after project compilation.

## Installing

```powershell
Install-Package SourceGeneration.Blazor.TailwindCss -Version 1.0.0-beta1.250201.1
```

```powershell
dotnet add package SourceGeneration.Blazor.TailwindCss --version 1.0.0-beta1.250201.1
```

## Features

### Responsive screen breakpoints
`SourceGeneration.Blazor.TailwindCss` fully supports responsive prefixes (e.g., sm:, md:, lg:, xs:, xl:) for all CSS classes, enabling adaptive designs across screen breakpoints.

```html
<div class="xs:mt-1 sm:mt-2 md:mt-3 lg:mt-4 xl:mt-5">
    <span class="xs:text-xs sm:text-sm md:text-base lg:text-lg xl:text-xl"></span>
</div>
```
### Extended size ranges
`SourceGeneration.Blazor.TailwindCss` extends Tailwind's utility classes by supporting:

- Extended size ranges (e.g., p-1.5, p-200)
- Decimal values parsed as floating-point numbers
- Customizable spacing scale ({number} * 0.25rem)

```html
<Component class="p-1.5 md:p-200" /> 
<!-- Generates: -->
<style>
.p-1\.5 { padding: 0.375rem; }
.md\:p-200 { padding: 50rem; }
</style>
```

## Styles

#### LAYOUT
- [ ] aspect-ratio
- [ ] columns
- [ ] break-after
- [ ] break-before
- [ ] break-inside
- [ ] box-decoration-break
- [ ] box-sizing
- [X] display
- [ ] float
- [ ] clear
- [ ] isolation
- [ ] object-fit
- [ ] object-position
- [x] overflow
- [ ] overscroll-behavior
- [x] position
- [x] top / right / bottom / left
- [ ] visibility
- [x] z-index

#### FLEXBOX & GRID
- [ ] flex-basis
- [x] flex-direction
- [x] flex-wrap
- [x] flex
- [ ] flex-grow
- [ ] flex-shrink
- [ ] order
- [x] grid-template-columns
- [ ] grid-column
- [ ] grid-template-rows
- [ ] grid-row
- [ ] grid-auto-flow
- [ ] grid-auto-columns
- [ ] grid-auto-rows
- [x] gap
- [x] justify-content
- [x] justify-items
- [x] justify-self
- [ ] align-content
- [x] align-items
- [ ] align-self
- [ ] place-content
- [ ] place-items
- [ ] place-self

#### PACEING
- [x] padding
- [x] margin

#### SIZING
- [x] width
- [x] min-width
- [x] max-width
- [x] height
- [x] min-height
- [x] max-height

#### TYPOGRAPHY
- [x] font-family
- [x] font-size
- [ ] font-smoothing
- [ ] font-style
- [x] font-weight
- [ ] font-stretch
- [ ] font-variant-numeric
- [ ] letter-spacing
- [x] line-clamp
- [ ] line-height
- [ ] list-style-image
- [ ] list-style-position
- [ ] list-style-type
- [x] text-align
- [x] color
- [ ] text-decoration-line
- [ ] text-decoration-color
- [ ] text-decoration-style
- [ ] text-decoration-thickness
- [ ] text-underline-offset
- [ ] text-transform
- [ ] text-overflow
- [ ] text-wrap
- [ ] text-indent
- [ ] vertical-align
- [ ] white-space
- [ ] word-break
- [ ] hyphens
- [ ] content

#### BACKGROUNDS
- [ ] background-attachment
- [ ] background-clip
- [x] background-color
- [ ] background-image
- [ ] background-origin
- [ ] background-position
- [ ] background-repeat
- [ ] background-size

#### BORDERS
- [x] border-radius
- [x] border-width
- [x] border-color
- [x] border-style
- [ ] outline-width
- [ ] outline-color
- [ ] outline-style
- [ ] outline-offset

#### EFFECTS
- [x] box-shadow
- [ ] opacity
- [ ] mix-blend-mode
- [ ] background-blend-mode

#### FILTERS
- [ ] filter
- [ ] blur
  - [ ] brightness
  - [ ] contrast
  - [ ] drop-shadow
  - [ ] grayscale
  - [ ] hue-rotate
  - [ ] invert
  - [ ] saturate
  - [ ] sepia
- [ ] backdrop-filter
  - [ ] blur
  - [ ] brightness
  - [ ] contrast
  - [ ] grayscale
  - [ ] hue-rotate
  - [ ] invert
  - [ ] opacity
  - [ ] saturate
  - [ ] sepia

#### TABLES
- [ ] border-collapse
- [ ] border-spacing
- [ ] table-layout
- [ ] caption-side

#### TRANSITIONS & ANIMATION
- [ ] transition-property
- [ ] transition-behavior
- [ ] transition-duration
- [ ] transition-timing-function
- [ ] transition-delay
- [ ] animation

#### TRANSFORMS
- [ ] backface-visibility
- [ ] perspective
- [ ] perspective-origin
- [ ] rotate
- [ ] scale
- [ ] skew
- [ ] transform
- [ ] transform-origin
- [ ] transform-style
- [ ] translate

#### INTERACTIVITY
- [ ] accent-color
- [ ] appearance
- [ ] caret-color
- [ ] color-scheme
- [x] cursor
- [ ] field-sizing
- [ ] pointer-events
- [ ] resize
- [x] scroll-behavior
- [ ] scroll-margin
- [ ] scroll-padding
- [ ] scroll-snap-align
- [ ] scroll-snap-stop
- [ ] scroll-snap-type
- [ ] touch-action
- [ ] user-select
- [ ] will-change

#### SVG
- [ ] fill
- [ ] stroke
- [ ] stroke-width

#### ACCESSIBILITY
- [ ] forced-color-adjust
