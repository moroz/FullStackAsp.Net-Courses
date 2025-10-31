<script lang="ts">
	import type { Snippet } from "svelte";

	interface Props {
		title?: string;
	}

	let { title }: Props = $props();
</script>

<svelte:head>
	{#if title}
		<title>{title} | Homeo sapiens</title>
	{:else}
		<title>Homeo sapiens</title>
	{/if}
</svelte:head>
