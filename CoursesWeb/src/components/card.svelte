<script lang="ts">
	import type { Snippet } from "svelte";
	import { twMerge } from "tailwind-merge";

	interface Props {
		children: Snippet;
		class?: string;
	}

	const { children, class: className }: Props = $props();
</script>

<div class={twMerge("rounded-lg border-2 bg-white p-6", className)}>
	{@render children?.()}
</div>
