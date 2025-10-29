export default {
	forms: {
		required_title: "required field",
	},
	header: {
		nav: {
			sign_in: "Sign in",
			events: "Events",
			videos: "Videos",
			my_products: "My products",
		},
	},
	hosts: {
		salutation: {
			dr: "Dr.",
		},
	},
	users: {
		new: {
			header: "Sign up",
			email: "Email:",
			password: "Choose a password:",
			confirm_password: "Confirm password:",
			given_name: "Given name:",
			family_name: "Family name:",
			already_have_an_account_html: `Already have an account? <a href="{{path}}">Sign in</a>`,
			submit: "Sign up",
			helpers: {
				password: "{{min}}–{{max}} characters",
			},
		},
	},
	sessions: {
		common: {
			go_back: "Go back",
		},
		new: {
			header: "Sign in",
			email: "Email:",
			password: "Password:",
			submit: "Sign in",
			no_account_yet_html: `Don't have an account? <a href="{{path}}">Sign up</a>`,
		},
	},
	events: {
		event_type: {
			Seminar: "Seminar",
			Webinar: "Webinar",
		},
	},
};
