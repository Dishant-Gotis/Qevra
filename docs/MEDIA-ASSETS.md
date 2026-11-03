# Qevra Media Assets Register
**Comprehensive Inventory & Technical Specification for Brand Media**

---

## 1. Overview

This document defines the exact dimensions, formats, aspect ratios, and visual specifications required for **Qevra** media assets.

---

## 2. Documentation & Marketing Media (`docs/media/`)

The following 19 assets represent the visual media for documentation and promotion:

### A. Promotional Banners & Social Cards
| Target Filename | Dimensions | Format | Aspect Ratio | Description / Visual Contents |
|---|---|---|---|---|
| `banner-en.jpg` | **1280 × 640 px** | JPEG / WebP | 2:1 | Hero banner showing Qevra tagline: *"Qevra: Drag. Drop. Converted."* with Qevra branding. |
| `banner-ko.jpg` | **1280 × 640 px** | JPEG / WebP | 2:1 | Korean localized hero banner. |
| `banner-zh-CN.jpg` | **1280 × 640 px** | JPEG / WebP | 2:1 | Simplified Chinese localized hero banner. |
| `social-preview.jpg` | **1280 × 640 px** | JPEG | 2:1 | GitHub repository social preview / Open Graph card image. |

### B. Animated Demonstrations
| Target Filename | Dimensions | Format | Description / Frame Contents |
|---|---|---|---|
| `demo-en.webp` | **900 × 506 px** | Animated WebP | Animation demonstrating: holding `Ctrl`, dragging a sample file, radial donut menu popping up at cursor, dropping onto format slice, progress ring completing. |
| `demo-ko.webp` | **900 × 506 px** | Animated WebP | Korean localized animated demo. |
| `demo-zh-CN.webp` | **900 × 506 px** | Animated WebP | Simplified Chinese localized animated demo. |

### C. Application UI Screenshots
| Target Filename | Dimensions | Format | Description / View Shown |
|---|---|---|---|
| `page-home-en.png` | **1080 × 820 px** | PNG (24-bit) | Main dashboard Home page showing the Drop Zone and Recent Conversions list. |
| `page-home-ko.png` | **1080 × 820 px** | PNG (24-bit) | Korean localized Home page. |
| `page-home-zh-CN.png` | **1080 × 820 px** | PNG (24-bit) | Simplified Chinese localized Home page. |
| `page-toolbar-en.png` | **1080 × 820 px** | PNG (24-bit) | Donut Toolbar editor page (Light Theme), displaying profile slice arrangement. |
| `page-toolbar-dark.png` | **1080 × 820 px** | PNG (24-bit) | Donut Toolbar editor page (Dark Theme). |
| `page-toolbar-ko.png` | **1080 × 820 px** | PNG (24-bit) | Korean localized Donut Toolbar editor. |
| `page-toolbar-zh-CN.png`| **1080 × 820 px** | PNG (24-bit) | Simplified Chinese localized Donut Toolbar editor. |
| `page-presets-en.png` | **1080 × 820 px** | PNG (24-bit) | Presets page with format categories, quality sliders, and output rules. |
| `page-presets-zh-CN.png`| **1080 × 820 px** | PNG (24-bit) | Simplified Chinese localized Presets page. |
| `engine-setup-en.png` | **560 × 1080 px** | PNG (24-bit) | Settings → Engines setup dialog listing external converters. |
| `engine-setup-ko.png` | **560 × 1080 px** | PNG (24-bit) | Korean localized Engines setup dialog. |
| `preset-popup-ko.png` | **560 × 680 px** | PNG (24-bit) | Preset Editor modal sheet with conversion parameters. |

---

## 3. Brand Identity & Application Icons (`src/Qevra.App/Assets/Icons/`)

Qevra logo icons:

| Asset Path | Format | Dimensions | Purpose |
|---|---|---|---|
| `src/Qevra.App/Assets/Icons/qevra.ico` | Multi-layer ICO | 16×16, 24×24, 32×32, 48×48, 64×64, 128×128, 256×256 | Main Windows desktop executable icon, tray icon, and window titlebars. |
| `src/Qevra.App/Assets/Icons/qevra.png` | PNG (RGBA) | 512 × 512 px | Linux desktop launcher icon, macOS dock icon, and high-DPI displays. |
| `src/Qevra.App/Assets/Icons/qevra.svg` | Scalable Vector | Vector | Source vector artwork for scaling across all resolutions. |

---

## 4. In-App "What's New" Slide Decks (`src/Qevra.App/Assets/WhatsNew/`)

The application features an interactive slideshow that introduces features upon first launch or update:

### Release 2.0.0 Slides (`src/Qevra.App/Assets/WhatsNew/2.0.0/`)
| Filename | Resolution | Format | Purpose |
|---|---|---|---|
| `browser.webp` | 640 × 360 px | Animated WebP | Demonstrates dragging files/images directly from web browsers. |
| `crop.webp` | 768 × 432 px | Animated WebP | Demonstrates interactive image cropping tool before conversion. |
| `flip.webp` | 640 × 360 px | Animated WebP | Demonstrates flipping donut menu faces with `Tab` or mouse wheel. |
| `formats.webp` | 768 × 432 px | Animated WebP | Overview of supported file format categories. |
| `languages.webp` | 768 × 432 px | Animated WebP | Language switching and RTL Arabic support. |
| `theme.webp` | 768 × 432 px | Animated WebP | Custom themes, accent colors, and opacity adjustments. |
| `more.webp` | 768 × 432 px | Animated WebP | Overview of additional utilities (watch folders, CLI). |
| `pt-BR/*.webp` | 768 × 432 px | Animated WebP | Brazilian Portuguese localized slide variants (crop, formats, more, theme). |
| `pt-PT/*.webp` | 768 × 432 px | Animated WebP | Portugal Portuguese localized slide variants (crop, formats, more, theme). |

### Release 2.3.0 Slides (`src/Qevra.App/Assets/WhatsNew/2.3.0/`)
| Filename | Resolution | Format | Purpose |
|---|---|---|---|
| `annotate.webp` | 768 × 432 px | Animated WebP | Demonstrates vector annotation canvas (arrows, pens, highlighters). |
| `crop_video.webp` | 768 × 432 px | Animated WebP | Demonstrates video cropping and black-bar auto-detection. |
| `fields.webp` | 768 × 432 px | Animated WebP | Metadata and EXIF fields configuration. |
| `sheets.webp` | 768 × 432 px | Animated WebP | Spreadsheet Print Studio workflow. |
| `translate.webp` | 768 × 432 px | Animated WebP | AI document and subtitle translation. |
| `more.webp` | 768 × 432 px | Animated WebP | Additional conversion enhancements. |

---

## 5. Technical Requirements for Asset Generation

1. **Resolution & Density**:
   - High-DPI support: UI screenshots should be captured on 100% or 200% scaling displays without distortion.
   - Text legibility: Keep UI text sharp with anti-aliasing.
2. **Animation Parameters for WebP**:
   - Frame rate: 24–30 fps.
   - Loop count: Infinite (`0`).
   - Frame duration: ~30–40 ms per frame; pauses on key steps should be ~800–1200 ms.
   - Max file size: Under 500 KB per slide for fast in-app decoding.
3. **Color Profile**:
   - Standard sRGB color space.
