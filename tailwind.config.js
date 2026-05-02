import forms from "@tailwindcss/forms";

const maxWidth = "clamp(800px, 85%, 1440px)";

export default {
    content: [
        "./resources/**/*.blade.php",
        "./resources/**/*.php",
        "./resources/**/*.js",
        "./app/**/*.php",
        "./routes/**/*.php",
    ],
    safelist: [
        "h1-title",
        "h2-title",
        "h3-title",
        "h4-title",
        "h5-title",
        "big-text",
        "regular-text",
        "small-text",
    ],
    theme: {
        screens: {
            desktop: "1900px",
            xxl: "1550px",
            xl: "1441px",
            desktopLg: "1380px",
            lg: "1241px",
            laptopMd: "1025px",
            md: "769px",
            sm: "641px",
            xs: "451px",
        },
        extend: {
            colors: {
                main: "#F5F5F0",
                secondary: "#4A2C2A",
                title: "#321716",
                desc: "#8F6F6B",
                paper: "#F5F5F0",
                ink: "#321716",
                clay: "#4A2C2A",
                moss: "#8F6F6B",
                brass: "#8F6F6B",
                secondaryTitle: "#1B1B1C",
            },
            fontFamily: {
                desc: [
                    "SourceSans3",
                    "ui-sans-serif",
                    "system-ui",
                    "sans-serif",
                ],
                title: ["LiberationSerif", "Georgia", "serif"],
                link: [
                    "SpaceGrotesk",
                    "ui-sans-serif",
                    "system-ui",
                    "sans-serif",
                ],
            },
            borderRadius: {
                xxl: "50%",
            },
            boxShadow: {
                soft: "0 18px 60px rgb(22 22 22 / 0.10)",
            },

            maxWidth: {
                xl: maxWidth,
                wideXl: `calc(100vw - (100vw - ${maxWidth})/2)`,
            },
        },
    },
    plugins: [forms],
};
