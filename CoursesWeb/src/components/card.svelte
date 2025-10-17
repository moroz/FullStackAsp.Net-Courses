<script lang="ts">
	import type { Snippet } from "svelte";
	import { twMerge } from "tailwind-merge";

	interface Props {
		children: Snippet;
		class?: string;
	}

	const { children, class: className }: Props = $props();
</script>

<div class={twMerge("rounded-sm border border-slate-300 bg-white p-6 shadow", className)}>
	{@render children?.()}
</div>
