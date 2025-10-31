<script lang="ts">
	import type { Snippet } from "svelte";
	import { twMerge } from "tailwind-merge";

	interface ButtonProps {
		href?: never;
		type?: "submit" | "reset" | "button";
		disabled?: boolean;
	}

	interface LinkProps {
		href: string;
		type?: never;
		disabled?: never;
	}

	type Props = (ButtonProps | LinkProps) & {
		children: Snippet;
		class?: string;
		variant?: "primary";
	};

	const { children, href, class: className, type, variant, disabled }: Props = $props();
</script>

<svelte:element
	this={href ? "a" : "button"}
	data-button
	{type}
	{href}
	{disabled}
	class={twMerge(
		"button item-center z-10 -mt-[5px] -ml-[5px] inline-flex cursor-pointer justify-center rounded border-2 border-black bg-white p-2 text-primary shadow-solid transition-all hover:translate-[4px] hover:shadow-none",
		variant === "primary" && "bg-indigo-800 text-white disabled:bg-gray-100 disabled:text-black",
		className,
	)}
>
	{@render children?.()}
</svelte:element>
