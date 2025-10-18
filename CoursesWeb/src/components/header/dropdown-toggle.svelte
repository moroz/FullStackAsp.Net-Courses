<script lang="ts">
	import type { User } from "@api/interfaces";
	import Avatar from "@components/avatar.svelte";

	interface Props {
		user: User;
		open: boolean;
	}

	const { open, user }: Props = $props();

	const fullName = [user.salutation, user.givenName, user.familyName].filter(Boolean).join(" ");
	const title = `${fullName}\n(${user.email})`;
</script>

<button
	class="flex h-full cursor-pointer items-center justify-center rounded-sm px-3 transition-colors hover:bg-slate-200"
	aria-haspopup="true"
	aria-expanded={open}
	{title}
>
	<Avatar {user} class="h-[34px]" />
</button>
