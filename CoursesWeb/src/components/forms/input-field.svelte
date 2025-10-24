<script lang="ts">
	import { t } from "$lib/translations";
	import { twMerge } from "tailwind-merge";
	import type { HTMLInputAttributes } from "svelte/elements";

	interface Props extends HTMLInputAttributes {
		labelKey: string;
		class?: string;
		error?: string | string[] | null;
	}

	let { name, labelKey, value = $bindable(), class: className, error, ...rest }: Props = $props();

	let resolvedError = $derived.by(() => {
		if (typeof error === "string") {
			return error;
		}
		if (Array.isArray(error)) {
			return error[0] ?? null;
		}
		return null;
	});
</script>

<label class="grid gap-1">
	<span class="leading-tight font-bold">{$t(labelKey)}</span>
	<input
		type="text"
		bind:value
		{name}
		aria-invalid={error ? "true" : undefined}
		class={twMerge(
			"h-10 rounded-sm border border-slate-500 px-3",
			error && "border-red-500",
			className,
		)}
		{...rest}
	/>
	{#if resolvedError}
		<span class="error-explanation text-sm text-red-900">{error}</span>
	{/if}
</label>
