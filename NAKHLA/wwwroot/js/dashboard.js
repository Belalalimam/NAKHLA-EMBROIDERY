// dashboard.js - Fixed Version with Working Modals

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', function () {
    console.log('Dashboard initialized');

    // Initialize mobile navigation
    initMobileNavigation();

    // Initialize search
    initSearch();

    // Initialize button animations
    initButtonAnimations();

    // Initialize filter dropdowns
    initFilterDropdowns();

    // Initialize modals
    initModals();

    // Test if icons are working
    testIcons();
});

// ===== MOBILE NAVIGATION =====
function initMobileNavigation() {
    const sideNav = document.getElementById('sideNav');
    const navToggle = document.getElementById('navToggle');
    const navClose = document.getElementById('navClose');
    const mobileOverlay = document.getElementById('mobileOverlay');

    if (navToggle) {
        navToggle.addEventListener('click', function () {
            sideNav.classList.add('active');
            mobileOverlay.classList.add('active');
            document.body.style.overflow = 'hidden';
        });
    }

    if (navClose) {
        navClose.addEventListener('click', function () {
            sideNav.classList.remove('active');
            mobileOverlay.classList.remove('active');
            document.body.style.overflow = 'auto';
        });
    }

    if (mobileOverlay) {
        mobileOverlay.addEventListener('click', function () {
            sideNav.classList.remove('active');
            mobileOverlay.classList.remove('active');
            document.body.style.overflow = 'auto';
        });
    }
}

// ===== SEARCH FUNCTIONALITY =====
function initSearch() {
    const searchInput = document.getElementById('globalSearch');
    if (!searchInput) return;

    let searchTimeout;

    searchInput.addEventListener('input', function () {
        clearTimeout(searchTimeout);
        const term = this.value.trim();

        if (term.length >= 2) {
            searchTimeout = setTimeout(() => {
                console.log('Searching for:', term);
                // Highlight matching rows
                highlightSearchResults(term);
            }, 300);
        } else {
            clearSearch();
        }
    });
}

function highlightSearchResults(term) {
    const rows = document.querySelectorAll('table tbody tr');
    rows.forEach(row => {
        const text = row.textContent.toLowerCase();
        if (text.includes(term.toLowerCase())) {
            row.style.backgroundColor = '#fffaf0';
        } else {
            row.style.backgroundColor = '';
        }
    });
}

function clearSearch() {
    const rows = document.querySelectorAll('table tbody tr');
    rows.forEach(row => {
        row.style.backgroundColor = '';
    });
}

// ===== BUTTON ANIMATIONS =====
function initButtonAnimations() {
    document.addEventListener('click', function (e) {
        const btn = e.target.closest('.filter-btn, .btn, .table-action, .row-action, .modal-action, .page-item');
        if (btn && !btn.classList.contains('disabled')) {
            btn.classList.add('click-animation');
            setTimeout(() => btn.classList.remove('click-animation'), 150);
        }
    });
}

// ===== FILTER DROPDOWNS =====
function initFilterDropdowns() {
    const filterBtns = document.querySelectorAll('.filter-group .filter-btn');

    filterBtns.forEach(btn => {
        btn.addEventListener('click', function (e) {
            e.stopPropagation();
            filterBtns.forEach(b => {
                if (b !== this) b.classList.remove('active');
            });
            this.classList.toggle('active');
        });
    });

    document.addEventListener('click', function () {
        filterBtns.forEach(btn => btn.classList.remove('active'));
    });
}

// ===== MODAL SYSTEM (FIXED) =====
function initModals() {
    // Close modals with ESC key
    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') {
            closeModal();
            closeConfirmModal();
        }
    });

    // Close modals when clicking outside
    document.addEventListener('click', function (e) {
        if (e.target.classList.contains('modal')) {
            closeModal();
            closeConfirmModal();
        }
    });

    console.log('Modal system initialized');
}

// ===== ORDER MODAL FUNCTIONS =====
function openOrderModal(orderId, event) {
    if (event) {
        event.stopPropagation();
        event.preventDefault();
    }

    console.log('Opening modal for order:', orderId);

    // Set modal title
    document.getElementById('modalOrderId').textContent = `Order #${orderId}`;

    // Load order details
    const modalBody = document.getElementById('modalBody');
    modalBody.innerHTML = getOrderDetailsHTML(orderId);

    // Show modal
    const modal = document.getElementById('orderModal');
    modal.style.display = 'flex';
    document.body.style.overflow = 'hidden';

    // Initialize tabs
    initModalTabs();
}

function getOrderDetailsHTML(orderId) {
    // Sample data - in real app, fetch from API
    const orders = {
        '192541': {
            customer: 'Esther Howard',
            email: 'brodrigues@gmail.com',
            phone: '+1 (415) 555-2671',
            items: [
                { name: 'Stihl TS 800 cut-off machine incl.', desc: '5x diamond cutting discs', qty: 1, price: 1590.00 },
                { name: 'Gasoline generator EYG 7500I', desc: '(inverter)', qty: 1, price: 337.89 }
            ],
            total: 1927.89
        }
    };

    const order = orders[orderId] || {
        customer: 'Customer',
        email: 'email@example.com',
        phone: '+1 (555) 123-4567',
        items: [
            { name: 'Product 1', desc: 'Description', qty: 1, price: 100.00 }
        ],
        total: 100.00
    };

    return `
        <div class="order-details">
            <div class="customer-info">
                <h4>${order.customer}</h4>
                <p><i class="fas fa-envelope"></i> ${order.email}</p>
                <p><i class="fas fa-phone"></i> ${order.phone}</p>
            </div>
            
            <div class="order-tabs">
                <button class="tab-btn active" data-tab="items">Order Items</button>
                <button class="tab-btn" data-tab="delivery">Delivery</button>
                <button class="tab-btn" data-tab="docs">Documents</button>
            </div>
            
            <div class="tab-content active" id="tab-items">
                <div class="order-items">
                    ${order.items.map(item => `
                        <div class="order-item">
                            <div class="item-info">
                                <h5>${item.name}</h5>
                                <p>${item.desc}</p>
                            </div>
                            <div class="item-price">
                                <span>${item.qty} × $${item.price.toFixed(2)}</span>
                                <strong>$${(item.qty * item.price).toFixed(2)}</strong>
                            </div>
                        </div>
                    `).join('')}
                </div>
                
                <div class="order-total">
                    <strong>Total: $${order.total.toFixed(2)}</strong>
                </div>
            </div>
            
            <div class="tab-content" id="tab-delivery">
                <p>Delivery information for order #${orderId}</p>
                <p><strong>Address:</strong> 123 Main Street, San Francisco, CA 94107</p>
                <p><strong>Status:</strong> Shipped</p>
                <p><strong>Estimated Delivery:</strong> June 25, 2025</p>
            </div>
            
            <div class="tab-content" id="tab-docs">
                <p>Documents for order #${orderId}</p>
                <ul>
                    <li><i class="fas fa-file-invoice"></i> Invoice #INV-${orderId}</li>
                    <li><i class="fas fa-receipt"></i> Receipt #REC-${orderId}</li>
                    <li><i class="fas fa-shipping-fast"></i> Shipping Label #SL-${orderId}</li>
                </ul>
            </div>
            
            <div class="modal-actions">
                <button class="btn btn-primary" onclick="exportOrder('${orderId}')">
                    <i class="fas fa-file-export"></i> Export Order
                </button>
                <button class="btn btn-secondary" onclick="duplicateOrder('${orderId}')">
                    <i class="fas fa-copy"></i> Duplicate
                </button>
                <button class="btn btn-secondary" onclick="printOrder('${orderId}')">
                    <i class="fas fa-print"></i> Print
                </button>
            </div>
        </div>
    `;
}

function initModalTabs() {
    const tabButtons = document.querySelectorAll('.tab-btn');
    const tabContents = document.querySelectorAll('.tab-content');

    tabButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Remove active class from all buttons and contents
            tabButtons.forEach(btn => btn.classList.remove('active'));
            tabContents.forEach(content => content.classList.remove('active'));

            // Add active class to clicked button
            this.classList.add('active');

            // Show corresponding content
            const tabId = this.getAttribute('data-tab');
            document.getElementById(`tab-${tabId}`).classList.add('active');
        });
    });
}

function closeModal() {
    const modal = document.getElementById('orderModal');
    modal.style.display = 'none';
    document.body.style.overflow = 'auto';
}

// ===== ORDER ACTIONS =====
function exportOrder(orderId) {
    console.log('Exporting order:', orderId);
    alert(`Exporting order #${orderId}...`);
}

function duplicateOrder(orderId) {
    console.log('Duplicating order:', orderId);
    alert(`Duplicating order #${orderId}...`);
}

function printOrder(orderId) {
    console.log('Printing order:', orderId);
    window.print();
}

// ===== SELECTION MANAGEMENT =====
let selectedOrders = new Set();

function selectOrderRow(event, row) {
    // Don't trigger if clicking on checkbox or action buttons
    if (event.target.type === 'checkbox' ||
        event.target.closest('.row-actions') ||
        event.target.closest('.product-info')) {
        return;
    }

    const checkbox = row.querySelector('.order-select');
    if (checkbox) {
        checkbox.checked = !checkbox.checked;
        updateSelection(checkbox);
    }
}

function updateSelection(checkbox) {
    const orderId = checkbox.value;

    if (checkbox.checked) {
        selectedOrders.add(orderId);
        checkbox.closest('tr').classList.add('selected');
    } else {
        selectedOrders.delete(orderId);
        checkbox.closest('tr').classList.remove('selected');
        document.getElementById('selectAll').checked = false;
    }

    updateSelectionUI();
}

function toggleSelectAll(selectAllCheckbox) {
    const checkboxes = document.querySelectorAll('.order-select');
    checkboxes.forEach(checkbox => {
        checkbox.checked = selectAllCheckbox.checked;
        updateSelection(checkbox);
    });
}

function updateSelectionUI() {
    const count = selectedOrders.size;
    const selectedCountEl = document.getElementById('selectedCount');
    const actionsBar = document.getElementById('selectionActions');

    if (selectedCountEl) {
        selectedCountEl.textContent = count;
    }

    if (actionsBar) {
        if (count > 0) {
            actionsBar.classList.add('active');
        } else {
            actionsBar.classList.remove('active');
        }
    }
}

function clearSelection() {
    selectedOrders.clear();
    document.querySelectorAll('.order-select').forEach(cb => {
        cb.checked = false;
        cb.closest('tr').classList.remove('selected');
    });
    document.getElementById('selectAll').checked = false;
    updateSelectionUI();
}

// ===== BULK ACTIONS =====
function exportSelected() {
    if (selectedOrders.size === 0) {
        alert('Please select at least one order');
        return;
    }
    console.log('Exporting orders:', Array.from(selectedOrders));
    alert(`Exporting ${selectedOrders.size} selected orders...`);
}

function deleteSelected() {
    if (selectedOrders.size === 0) {
        alert('Please select at least one order');
        return;
    }

    if (confirm(`Delete ${selectedOrders.size} selected orders?`)) {
        console.log('Deleting orders:', Array.from(selectedOrders));
        // Remove from UI
        selectedOrders.forEach(id => {
            const row = document.querySelector(`tr[data-order-id="${id}"]`);
            if (row) row.remove();
        });
        clearSelection();
    }
}

// ===== CONFIRMATION MODAL =====
function showConfirmModal(title, message, onConfirm) {
    document.getElementById('confirmTitle').textContent = title;
    document.getElementById('confirmMessage').textContent = message;

    const confirmBtn = document.getElementById('confirmActionBtn');
    confirmBtn.onclick = function () {
        if (onConfirm) onConfirm();
        closeConfirmModal();
    };

    document.getElementById('confirmModal').style.display = 'flex';
    document.body.style.overflow = 'hidden';
}

function closeConfirmModal() {
    document.getElementById('confirmModal').style.display = 'none';
    document.body.style.overflow = 'auto';
}

// ===== UTILITY FUNCTIONS =====
function testIcons() {
    console.log('Testing Font Awesome...');
    const testIcon = document.createElement('i');
    testIcon.className = 'fas fa-test';
    document.body.appendChild(testIcon);

    const computed = window.getComputedStyle(testIcon, ':before');
    const content = computed.content;

    if (content === 'none' || content === 'normal') {
        console.warn('Font Awesome may not be loading properly');
        // Load emergency fallback
        const link = document.createElement('link');
        link.rel = 'stylesheet';
        link.href = 'https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@6.4.2/css/all.min.css';
        document.head.appendChild(link);
    }

    testIcon.remove();
}

// ===== GLOBAL FUNCTIONS =====
window.openOrderModal = openOrderModal;
window.closeModal = closeModal;
window.selectOrderRow = selectOrderRow;
window.updateSelection = updateSelection;
window.toggleSelectAll = toggleSelectAll;
window.clearSelection = clearSelection;
window.exportSelected = exportSelected;
window.deleteSelected = deleteSelected;
window.exportOrder = exportOrder;
window.duplicateOrder = duplicateOrder;
window.printOrder = printOrder;