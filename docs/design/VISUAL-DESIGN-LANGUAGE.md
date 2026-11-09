# Qevra — Visual Design Language

## 1. Design Philosophy

Design Qevra as a premium, trustworthy, modern desktop utility.

The interface should communicate:
- **Trust:** Reliable, predictable, and professional.
- **Clarity:** Every element has a purpose.
- **Sophistication:** Refined, understated, and visually balanced.
- **Efficiency:** Users should accomplish tasks without unnecessary friction.
- **Consistency:** Every screen should feel like part of the same product.

The design inspiration should come from professionally designed software such as Linear, Raycast, Arc, Vercel, and carefully crafted macOS applications.

Do NOT make Qevra look like a generic AI-generated SaaS dashboard.

## 2. Color Philosophy

The most important principle:

**Classy and trustworthy does not mean using dark backgrounds, excessive gradients, neon colors, or purple everywhere.**

Use a restrained color palette with strong neutral foundations and a carefully controlled purple accent.

Purple represents Qevra's identity. It should be an accent, not the dominant color of every component.

### Primary Brand Palette

- Primary Purple: `#6546D7`
- Deep Purple: `#4930A8`
- Soft Purple: `#F0ECFF`
- Light Lavender: `#F7F5FC`
- Brand Highlight: `#8065EB`

### Light Theme

The light theme should feel clean, sophisticated, and comfortable for extended use.

- Main Background: `#F8F9FC`
- Surface: `#FFFFFF`
- Secondary Surface: `#F1F2F7`
- Elevated Surface: `#FFFFFF`
- Primary Text: `#171827`
- Secondary Text: `#62677A`
- Muted Text: `#9297A8`
- Borders: `#E5E7EF`
- Primary Accent: `#6546D7`
- Accent Hover: `#5538C0`
- Accent Soft Background: `#F0ECFF`

### Dark Theme

The dark theme should feel sophisticated, not cyberpunk.

Avoid pure black backgrounds. Use carefully selected charcoal and navy-tinted neutrals.

- Main Background: `#111219`
- Surface: `#191B25`
- Secondary Surface: `#202330`
- Elevated Surface: `#262938`
- Primary Text: `#F3F3F8`
- Secondary Text: `#A5A8B8`
- Muted Text: `#777D91`
- Borders: `#303345`
- Primary Accent: `#8B72E8`
- Accent Hover: `#A08BF1`
- Accent Soft Background: `#29233F`

### Semantic Colors

Use semantic colors consistently.

- Success: `#23976B`
- Success Background: `#E9F6EF`
- Warning: `#C58A32`
- Warning Background: `#FFF5E5`
- Error: `#D34F5A`
- Error Background: `#FCEDEF`
- Information: `#4779C7`
- Information Background: `#EBF2FC`

Adapt semantic background colors for dark mode while maintaining sufficient contrast.

## 3. Color Usage Rules

Follow these rules strictly:

1. Approximately 70% of the interface should consist of neutral colors.
2. Approximately 20% should consist of secondary surfaces and subtle structural elements.
3. Approximately 10% should consist of brand accents and meaningful highlights.
4. Never use purple as the background for large sections unless there is a specific design reason.
5. Use purple primarily for primary actions, selected navigation items, active states, and important interactive elements.
6. Avoid unnecessary gradients.
7. Avoid neon glows, excessive shadows, and colorful borders.
8. Never use multiple competing accent colors.
9. Maintain readable contrast between text and backgrounds.
10. Do not use color alone to communicate success, failure, or warnings.

## 4. Typography

Typography should be clean, modern, and highly readable.

Preferred font families:
- Inter
- Geist
- SF Pro Display
- Segoe UI

Use an existing project font if it is already properly configured.

Typography guidelines:
- Use medium or semibold weights for headings.
- Use regular weights for descriptions.
- Avoid excessive bold text.
- Maintain consistent font sizes.
- Avoid unnecessarily large headings.
- Use appropriate line heights.
- Keep labels concise.

Recommended scale:
- Page Heading: 28–32px
- Section Heading: 18–22px
- Card Heading: 15–17px
- Body: 14–15px
- Secondary Text: 12–13px
- Small Labels: 11–12px

## 5. Layout & Spacing

The interface must feel organized and intentional.

- Use consistent spacing throughout the application.
- Prefer whitespace over unnecessary decorative elements.
- Maintain consistent alignment.
- Use predictable margins and padding.
- Avoid overcrowded layouts.
- Avoid excessively large empty spaces.
- Keep related controls visually grouped.

Use a consistent spacing scale based on 4px increments.

Recommended values:
- Tight: 4px
- Compact: 8px
- Standard: 12px
- Comfortable: 16px
- Section: 24px
- Large Section: 32px
- Major Separation: 48px

## 6. Components

### Buttons
- Primary buttons should use the brand purple.
- Secondary buttons should use neutral surfaces with subtle borders.
- Tertiary buttons should be minimal.
- Use consistent heights, padding, and corner radii.
- Hover states should be subtle.
- Avoid oversized pill-shaped buttons unless contextually appropriate.

### Cards
- Use neutral surfaces.
- Use subtle borders rather than heavy shadows.
- Avoid unnecessary nested cards.
- Use consistent corner radii.
- Reserve elevation for genuinely floating elements.

### Navigation
- Keep navigation minimal and predictable.
- Selected items should have a subtle purple background and accent-colored icon/text.
- Avoid excessively bright active states.
- Maintain consistent icon sizing.

### Inputs
- Use subtle borders.
- Provide clear focus indicators.
- Maintain consistent heights.
- Ensure placeholder text remains readable.
- Avoid unnecessary decorative elements.

### Icons
- Use one consistent icon family.
- Prefer Lucide icons.
- Maintain consistent stroke weight.
- Avoid mixing unrelated icon styles.
- Never use emoji as substitutes for interface icons.

## 7. Motion & Interactions

Animations should improve usability rather than attract attention.

- Use short, smooth transitions.
- Prefer 150–220ms transitions.
- Avoid excessive bouncing.
- Avoid continuous animations.
- Avoid unnecessary particle effects.
- Use subtle hover and focus transitions.
- Respect reduced-motion preferences.

## 8. Backgrounds & Effects

Avoid the typical AI-generated design aesthetic.

STRICTLY AVOID:
- Excessive purple gradients.
- Neon purple and blue glows.
- Glassmorphism everywhere.
- Frosted-glass cards without a functional reason.
- Heavy drop shadows.
- Random decorative circles.
- Unnecessary glowing borders.
- Excessive background patterns.
- Gradient text on ordinary headings.
- Decorative elements that compete with the actual product.

Prefer:
- Solid backgrounds.
- Subtle tonal differences.
- Thin, consistent borders.
- Restrained shadows.
- Clean separation between sections.

## 9. Qevra Brand Identity

Qevra should look like a serious, professionally engineered desktop application.

The brand identity should communicate:

- Reliable file conversion.
- Productivity and efficiency.
- Cross-format compatibility.
- Powerful customization.
- A polished desktop experience.

Keep the existing Qevra logo and its purple identity intact.

Do not redesign the logo, replace its colors, or introduce unrelated brand colors without explicit approval.

## 10. Implementation Rules

Before modifying any UI:

1. Inspect the existing project structure.
2. Identify the current styling system and component architecture.
3. Identify existing theme variables and reusable components.
4. Preserve all existing functionality.
5. Implement consistent design tokens.
6. Apply the design system across every screen.
7. Ensure light and dark themes are both consistent.
8. Test responsiveness and different window sizes.
9. Verify contrast, alignment, spacing, and component consistency.

Do not introduce unnecessary dependencies.

Do not rewrite working application logic just to change the appearance.

Do not create isolated styles for every screen when shared design tokens and components can solve the problem.

## 11. Final Design Standard

Before considering a screen complete, ask:

- Does this look like a professionally developed desktop application?
- Is the interface visually balanced?
- Is purple being used with restraint?
- Are the colors comfortable for extended usage?
- Is the hierarchy immediately understandable?
- Are the interactive elements predictable?
- Does the interface feel trustworthy?
- Does anything look unnecessarily decorative?

If an element does not improve usability, clarity, hierarchy, or brand identity, remove it.

**The ultimate direction: Minimal, refined, confident, functional, and timeless.**

Qevra should look premium because of its precision and restraint, not because of visual effects.

