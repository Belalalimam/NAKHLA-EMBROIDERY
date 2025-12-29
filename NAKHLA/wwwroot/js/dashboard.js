// dashboard.js - Clean, modular JavaScript

class Dashboard {
    constructor() {
        this.init();
    }

    init() {
        this.setupEventListeners();
        this.setupTooltips();
        this.setupSearch();
        this.setupUserDropdown();
        this.setupResponsive();
    }

    setupEventListeners() {
        // Button click animations
        document.addEventListener('click', (e) => {
            if (e.target.matches('.filter-btn, .btn, .table-action, .row-action')) {
                this.addClickAnimation(e.target);
            }
        });

        // Filter dropdown toggle
        document.addEventListener('click', (e) => {
            if (e.target.closest('.filter-group .filter-btn')) {
                this.toggleFilterDropdown(e.target.closest('.filter-btn'));
            }
        });

        // Close dropdowns when clicking outside
        document.addEventListener('click', (e) => {
            if (!e.target.closest('.user-profile') && !e.target.closest('.user-dropdown')) {
                this.closeUserDropdown();
            }

            if (!e.target.closest('.filter-group')) {
                this.closeAllFilterDropdowns();
            }
        });

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => {
            if (e.ctrlKey && e.key === 'f') {
                e.preventDefault();
                document.getElementById('globalSearch')?.focus();
            }

            if (e.key === 'Escape') {
                this.closeUserDropdown();
                this.closeAllFilterDropdowns();
            }
        });
    }

    setupTooltips() {
        const tooltipElements = document.querySelectorAll('[data-tooltip]');

        tooltipElements.forEach(element => {
            element.addEventListener('mouseenter', (e) => this.showTooltip(e));
            element.addEventListener('mouseleave', () => this.hideTooltip());
        });
    }

    showTooltip(event) {
        const element = event.target;
        const tooltipText = element.getAttribute('data-tooltip');
        if (!tooltipText) return;

        const tooltip = document.getElementById('tooltip');
        tooltip.textContent = tooltipText;
        tooltip.style.display = 'block';

        const rect = element.getBoundingClientRect();
        tooltip.style.top = `${rect.top - tooltip.offsetHeight - 10}px`;
        tooltip.style.left = `${rect.left + rect.width / 2 - tooltip.offsetWidth / 2}px`;
    }

    hideTooltip() {
        const tooltip = document.getElementById('tooltip');
        tooltip.style.display = 'none';
    }

    setupSearch() {
        const searchInput = document.getElementById('globalSearch');
        if (!searchInput) return;

        let searchTimeout;

        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.trim();

            // Clear previous timeout
            clearTimeout(searchTimeout);

            // Show loader for searches with 2+ characters
            if (searchTerm.length >= 2) {
                this.showSearchLoader(true);

                // Debounce search
                searchTimeout = setTimeout(() => {
                    this.performSearch(searchTerm);
                }, 300);
            } else {
                this.showSearchLoader(false);
                this.clearSearchResults();
            }
        });
    }

    performSearch(searchTerm) {
        // In a real application, this would be an API call
        console.log('Searching for:', searchTerm);

        // Simulate API delay
        setTimeout(() => {
            this.showSearchLoader(false);

            // Here you would typically update the table with search results
            // For now, just highlight matching text in the table
            this.highlightSearchResults(searchTerm);
        }, 500);
    }

    highlightSearchResults(searchTerm) {
        // Simple text highlighting - in a real app, you'd filter the table
        if (!searchTerm) return;

        const tableCells = document.querySelectorAll('table td, table th');
        tableCells.forEach(cell => {
            const text = cell.textContent;
            if (text.toLowerCase().includes(searchTerm.toLowerCase())) {
                cell.style.backgroundColor = '#fffaf0';
                cell.style.transition = 'background-color 0.3s';

                // Remove highlight after 2 seconds
                setTimeout(() => {
                    cell.style.backgroundColor = '';
                }, 2000);
            }
        });
    }

    showSearchLoader(show) {
        const loader = document.querySelector('.search-loader');
        if (loader) {
            loader.style.display = show ? 'block' : 'none';
        }
    }

    clearSearchResults() {
        // Clear any search highlighting
        const highlightedCells = document.querySelectorAll('table td[style*="background-color"]');
        highlightedCells.forEach(cell => {
            cell.style.backgroundColor = '';
        });
    }

    setupUserDropdown() {
        const userProfile = document.getElementById('userProfile');
        if (!userProfile) return;

        userProfile.addEventListener('click', (e) => {
            e.stopPropagation();
            this.toggleUserDropdown();
        });
    }

    toggleUserDropdown() {
        const dropdown = document.querySelector('.user-dropdown');
        if (dropdown) {
            const isVisible = dropdown.style.display === 'block';
            dropdown.style.display = isVisible ? 'none' : 'block';
            dropdown.classList.toggle('show', !isVisible);
        }
    }

    closeUserDropdown() {
        const dropdown = document.querySelector('.user-dropdown');
        if (dropdown) {
            dropdown.style.display = 'none';
            dropdown.classList.remove('show');
        }
    }

    toggleFilterDropdown(filterBtn) {
        const isActive = filterBtn.classList.contains('active');

        // Close all other filter dropdowns
        this.closeAllFilterDropdowns();

        // Toggle current dropdown
        if (!isActive) {
            filterBtn.classList.add('active');
        }
    }

    closeAllFilterDropdowns() {
        document.querySelectorAll('.filter-btn.active').forEach(btn => {
            btn.classList.remove('active');
        });
    }

    setupResponsive() {
        // Handle window resize with debouncing
        let resizeTimeout;
        window.addEventListener('resize', () => {
            clearTimeout(resizeTimeout);
            resizeTimeout = setTimeout(() => {
                this.handleResize();
            }, 250);
        });

        // Initial check
        this.handleResize();
    }

    handleResize() {
        const width = window.innerWidth;

        // Handle responsive behaviors
        if (width < 992) {
            // Mobile/tablet layout
            this.adaptForMobile();
        } else {
            // Desktop layout
            this.adaptForDesktop();
        }
    }

    adaptForMobile() {
        // Mobile-specific adaptations
        const userProfile = document.getElementById('userProfile');
        if (userProfile) {
            const userName = userProfile.querySelector('span');
            if (userName) {
                userName.style.display = 'none';
            }
        }
    }

    adaptForDesktop() {
        // Desktop-specific adaptations
        const userProfile = document.getElementById('userProfile');
        if (userProfile) {
            const userName = userProfile.querySelector('span');
            if (userName) {
                userName.style.display = 'inline';
            }
        }
    }

    addClickAnimation(element) {
        element.classList.add('click-animation');
        setTimeout(() => {
            element.classList.remove('click-animation');
        }, 150);
    }

    // Export functionality
    exportTableData(format = 'csv') {
        console.log(`Exporting table data as ${format}`);

        // Collect table data
        const table = document.querySelector('table');
        if (!table) return null;

        const rows = table.querySelectorAll('tr');
        const data = [];

        rows.forEach(row => {
            const rowData = [];
            row.querySelectorAll('th, td').forEach(cell => {
                // Exclude action buttons
                if (!cell.closest('.row-actions') && !cell.closest('.table-actions')) {
                    rowData.push(cell.textContent.trim());
                }
            });
            data.push(rowData);
        });

        // In a real application, you would:
        // 1. Send data to server for processing
        // 2. Generate file and trigger download
        // 3. Handle different formats (CSV, Excel, PDF)

        return data;
    }

    // Print functionality
    printTable() {
        const printContent = document.querySelector('.orders-container').cloneNode(true);

        // Remove action buttons for print
        printContent.querySelectorAll('.table-actions, .row-actions').forEach(el => {
            el.remove();
        });

        const printWindow = window.open('', '_blank');
        printWindow.document.write(`
            <html>
                <head>
                    <title>Print Orders</title>
                    <style>
                        body { font-family: Arial, sans-serif; margin: 20px; }
                        table { width: 100%; border-collapse: collapse; }
                        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                        th { background-color: #f5f5f5; }
                    </style>
                </head>
                <body>
                    <h2>Orders Report</h2>
                    ${printContent.innerHTML}
                </body>
            </html>
        `);
        printWindow.document.close();
        printWindow.print();
    }

    // Duplicate order (AJAX example)
    duplicateOrder(orderId) {
        if (!orderId) {
            console.error('No order ID provided');
            return;
        }

        // Show loading state
        const button = event?.target;
        if (button) {
            const originalText = button.textContent;
            button.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Duplicating...';
            button.disabled = true;
        }

        // Simulate API call
        setTimeout(() => {
            console.log(`Order ${orderId} duplicated`);

            // Show success message
            this.showNotification(`Order #${orderId} duplicated successfully`, 'success');

            // Restore button state
            if (button) {
                button.textContent = 'Duplicate';
                button.disabled = false;
            }
        }, 1000);
    }

    // Notification system
    showNotification(message, type = 'info') {
        // Check if notification container exists
        let container = document.getElementById('notification-container');
        if (!container) {
            container = document.createElement('div');
            container.id = 'notification-container';
            container.style.cssText = `
                position: fixed;
                top: 20px;
                right: 20px;
                z-index: 10000;
            `;
            document.body.appendChild(container);
        }

        // Create notification element
        const notification = document.createElement('div');
        notification.className = `notification notification-${type}`;
        notification.style.cssText = `
            background-color: ${type === 'success' ? '#48bb78' : type === 'error' ? '#f56565' : '#4299e1'};
            color: white;
            padding: 12px 20px;
            border-radius: 6px;
            margin-bottom: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            animation: slideIn 0.3s ease;
        `;

        notification.innerHTML = `
            <i class="fas fa-${type === 'success' ? 'check-circle' : type === 'error' ? 'exclamation-circle' : 'info-circle'}"></i>
            <span style="margin-left: 8px;">${message}</span>
        `;

        container.appendChild(notification);

        // Auto-remove after 3 seconds
        setTimeout(() => {
            notification.style.animation = 'slideOut 0.3s ease';
            setTimeout(() => {
                if (notification.parentNode) {
                    notification.parentNode.removeChild(notification);
                }
            }, 300);
        }, 3000);
    }

    // Table sorting (example)
    sortTable(columnIndex) {
        const table = document.querySelector('table');
        if (!table) return;

        const tbody = table.querySelector('tbody');
        const rows = Array.from(tbody.querySelectorAll('tr'));

        // Simple alphabetical sort for demonstration
        rows.sort((a, b) => {
            const aText = a.children[columnIndex].textContent.trim();
            const bText = b.children[columnIndex].textContent.trim();
            return aText.localeCompare(bText);
        });

        // Reorder rows
        rows.forEach(row => tbody.appendChild(row));
    }



    // dashboard.js - Add mobile navigation

document.addEventListener('DOMContentLoaded', function() {
        // Initialize mobile navigation
        initMobileNavigation();

        // Initialize existing dashboard functionality
        if (typeof dashboard !== 'undefined') {
            dashboard.init();
        }
    });

function initMobileNavigation() {
    const sideNav = document.getElementById('sideNav');
    const navToggle = document.getElementById('navToggle');
    const navClose = document.getElementById('navClose');
    const mobileOverlay = document.getElementById('mobileOverlay');

    // Toggle navigation
    if (navToggle) {
        navToggle.addEventListener('click', function () {
            sideNav.classList.add('active');
            mobileOverlay.classList.add('active');
            document.body.style.overflow = 'hidden';
        });
    }

    // Close navigation
    if (navClose) {
        navClose.addEventListener('click', function () {
            sideNav.classList.remove('active');
            mobileOverlay.classList.remove('active');
            document.body.style.overflow = 'auto';
        });
    }

    // Close nav when clicking overlay
    if (mobileOverlay) {
        mobileOverlay.addEventListener('click', function () {
            sideNav.classList.remove('active');
            mobileOverlay.classList.remove('active');
            document.body.style.overflow = 'auto';
        });
    }

    // Close nav on window resize (if resizing to desktop)
    window.addEventListener('resize', function () {
        if (window.innerWidth > 992) {
            sideNav.classList.remove('active');
            mobileOverlay.classList.remove('active');
            document.body.style.overflow = 'auto';
        }
    });
}

// Add click animation to buttons
document.addEventListener('click', function (e) {
    const btn = e.target.closest('.filter-btn, .btn, .table-action, .row-action, .modal-action');
    if (btn) {
        btn.classList.add('click-animation');
        setTimeout(() => btn.classList.remove('click-animation'), 150);
    }
});

}

// Initialize dashboard when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    window.dashboard = new Dashboard();

    // Make dashboard functions globally available
    window.exportTableData = (format) => window.dashboard.exportTableData(format);
    window.printTable = () => window.dashboard.printTable();
    window.duplicateOrder = (orderId) => window.dashboard.duplicateOrder(orderId);

    console.log('Dashboard initialized');
});


