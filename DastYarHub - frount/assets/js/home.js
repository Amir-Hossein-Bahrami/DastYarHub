const header = document.querySelector(".site-header");
const menuToggle = document.querySelector(".menu-toggle");
const mainNav = document.querySelector(".main-nav");

const searchInput = document.querySelector("#toolSearch");
const searchButton = document.querySelector("#searchButton");
const categoryButtons = document.querySelectorAll(".category-item");
const toolCards = document.querySelectorAll(".tool-card");
const toolsEmpty = document.querySelector("#toolsEmpty");

window.addEventListener("scroll", () => {
    header.classList.toggle("scrolled", window.scrollY > 40);
});

menuToggle?.addEventListener("click", () => {
    const isOpen = mainNav.classList.toggle("open");
    menuToggle.setAttribute("aria-expanded", String(isOpen));
});

document.querySelectorAll(".nav-link").forEach(link => {
    link.addEventListener("click", () => {
        mainNav.classList.remove("open");
        menuToggle.setAttribute("aria-expanded", "false");
    });
});

let selectedCategory = "all";

function filterTools() {
    const searchTerm = searchInput?.value.trim().toLowerCase() ?? "";
    let visibleCount = 0;

    toolCards.forEach(card => {
        const category = card.dataset.category ?? "";
        const title = card.dataset.title?.toLowerCase() ?? "";

        const matchesCategory =
            selectedCategory === "all" || category === selectedCategory;

        const matchesSearch =
            searchTerm === "" || title.includes(searchTerm);

        const visible = matchesCategory && matchesSearch;

        card.style.display = visible ? "" : "none";

        if (visible) {
            visibleCount++;
        }
    });

    if (toolsEmpty) {
        toolsEmpty.style.display = visibleCount === 0 ? "block" : "none";
    }
}

categoryButtons.forEach(button => {
    button.addEventListener("click", () => {
        categoryButtons.forEach(item => item.classList.remove("active"));
        button.classList.add("active");

        selectedCategory = button.dataset.category ?? "all";
        filterTools();
    });
});

searchInput?.addEventListener("input", filterTools);

searchButton?.addEventListener("click", () => {
    document.querySelector("#tools")?.scrollIntoView({ behavior: "smooth" });
    filterTools();
});
