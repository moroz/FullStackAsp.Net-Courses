<script lang="ts">
	import type { Snippet } from "svelte";
	import { twMerge } from "tailwind-merge";

	interface Props {
		children: Snippet;
		type?: "submit" | "reset" | "button";
		class?: string;
	}

	const { children, type, class: className }: Props = $props();
</script>

<button
	class={twMerge(
		"h-10 w-full cursor-pointer rounded-sm bg-primary-900 font-bold text-white transition-colors hover:bg-primary-800",
		className,
	)}
>
	{@render children?.()}
</button>
