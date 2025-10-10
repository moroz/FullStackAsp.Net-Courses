import tailwindcss from "@tailwindcss/vite";
import { sveltekit } from "@sveltejs/kit/vite";
import { defineConfig } from "vite";
import path from "path";

export default defineConfig({
	plugins: [tailwindcss(), sveltekit()],
	resolve: {
		alias: {
			"@components": path.resolve(process.cwd(), "src/components"),
			"@api": path.resolve(process.cwd(), "src/api"),
			"@": path.resolve(process.cwd(), "src"),
		},
	},
});
