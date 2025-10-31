<script lang="ts">
	import { t } from "$lib/translations";
	import { twMerge } from "tailwind-merge";
	import type { HTMLInputAttributes } from "svelte/elements";

	interface Props extends HTMLInputAttributes {
		labelKey: string;
		helperText?: string;
		class?: string;
		error?: string | string[] | null;
	}

	let {
		name,
		id = name,
		labelKey,
		helperText,
		value = $bindable(),
		class: className,
		error,
		...rest
	}: Props = $props();

	let resolvedError = $derived.by(() => {
		if (typeof error === "string") {
			return error;
		}
		if (Array.isArray(error)) {
			return error[0] ?? null;
		}
		return null;
	});

	let describedBy = $derived.by(() => {
		return (
			[resolvedError ? `${id}-error` : null, helperText ? `${id}-helper` : null]
				.filter(Boolean)
				.join(" ") || undefined
		);
	});
</script>

<label class="grid">
	<span class="leading-tight font-bold">
		{$t(labelKey)}
		{#if rest.required}
			<span class="text-red-800" title={$t("common.forms.required_title")}>*</span>
		{/if}
	</span>
	<input
		type="text"
		bind:value
		{name}
		aria-invalid={error ? "true" : undefined}
		aria-describedby={describedBy}
		class={twMerge(
			"mt-1 h-10 rounded-sm border-2 px-2",
			error && "border-red-700 focus-visible:outline-red-600",
			className,
		)}
		{...rest}
	/>
	{#if resolvedError}
		<span class="error-explanation text-sm text-red-900" id="{id}-error" role="alert"
			>{resolvedError}</span
		>
	{/if}
	{#if helperText}
		<span class="text-sm text-slate-600" id="{id}-helper">{helperText}</span>
	{/if}
</label>
